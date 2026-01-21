using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Rooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, ErrorOr<Room>>
    {
        private readonly ISubscriptionsRepository _subscriptionsRepositor;
        private readonly IGymsRepository _gymsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomCommandHandler(IUnitOfWork unitOfWork, IGymsRepository gymsRepository, ISubscriptionsRepository subscriptionsRepositor)
        {
            _unitOfWork = unitOfWork;
            _gymsRepository = gymsRepository;
            _subscriptionsRepositor = subscriptionsRepositor;
        }

        public async Task<ErrorOr<Room>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var gym =await _gymsRepository.GetByIdAsync(request.GymId);
            if (gym is null)
            {
                return Error.NotFound(description: "Gym not found.");
            }

            var subscription = await _subscriptionsRepositor.GetByIdAsync(gym.SubscriptionId);
            if (subscription is null)
            {
                return Error.NotFound(description: "Subscription not found.");
            }

            var room = new Room(request.RoomName,
                request.GymId,
                subscription.GetMaxDailySessions()
                );

            var addGymResult=gym.AddRoom(room);

            if (addGymResult.IsError)
            {
                return addGymResult.Errors;
            }

            await _gymsRepository.UpdateGymAsync(gym);
            await _unitOfWork.CommitChangesAsync();

            return room;
        }
    }
}
