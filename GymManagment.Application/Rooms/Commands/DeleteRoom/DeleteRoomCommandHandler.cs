using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using MediatR;

namespace GymManagment.Application.Rooms.Commands.DeleteRoom;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, ErrorOr<Deleted>>
{
    private readonly IGymsRepository _gymsRepository;
    private readonly IUnitOfWork _unitOfWork ;

    public DeleteRoomCommandHandler(IUnitOfWork unitOfWork, IGymsRepository gymsRepository)
    {
        _unitOfWork = unitOfWork;
        _gymsRepository = gymsRepository;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var gym=await _gymsRepository.GetByIdAsync(request.GymId);
        if(gym == null)
        {
            return Error.NotFound(description: "Gym not found.");
        }

        if(!gym.HasRoom(request.RoomId))
        {
            return Error.NotFound(description: "Room not found.");
        }

        gym.RemoveRoom(request.RoomId);

        await _gymsRepository.UpdateGymAsync(gym);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
