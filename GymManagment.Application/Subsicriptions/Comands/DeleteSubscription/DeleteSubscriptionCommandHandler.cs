using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagment.Application.Common.Interfaces;
using MediatR;

namespace GymManagment.Application.Subsicriptions.Comands.DeleteSubscription;

public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, ErrorOr<Deleted>>
{

    private readonly IAdminsRepository _adminsRepository;
    private readonly ISubsicriptionsRepository _subscriptionsRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGymsRepository _gymsRepository;
    public DeleteSubscriptionCommandHandler(IAdminsRepository adminsRepository, ISubsicriptionsRepository subscriptionsRepository, IUnitOfWork unitOfWork, IGymsRepository gymsRepository)
    {
       _adminsRepository = adminsRepository;
       _subscriptionsRepository = subscriptionsRepository;
       _unitOfWork = unitOfWork;
       _gymsRepository = gymsRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription=await _subscriptionsRepository.GetByIdAsync(request.SubscriptionId);
        if (subscription is null)
        {
            return Error.NotFound(description: "Subscription not found");
        }

        var admin = await _adminsRepository.GetByIdAsync(subscription.AdminId);
        if (admin is null)
        {
            return Error.Unexpected(description: "Admin not found");
        }
        admin.DeleteSubscription(subscription.Id);

        var gymToDelete = await _gymsRepository.ListBySubscriptionIdAsync(request.SubscriptionId);

        await _adminsRepository.UpdateAsync(admin);
        await _subscriptionsRepository.RemoveSubscriptionAsync(subscription);
        await _gymsRepository.RemoveRangeAsync(gymToDelete);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
