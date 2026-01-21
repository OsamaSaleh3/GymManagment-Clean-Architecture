using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Subsicriptions.Comands.CreateSubsicription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
    {

        private readonly ISubsicriptionsRepository _subsicriptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdminsRepository _adminsRepository;

        public CreateSubscriptionCommandHandler(ISubsicriptionsRepository subsicriptionRepository, IUnitOfWork unitOfWork, IAdminsRepository adminsRepository)
        {
            _subsicriptionRepository = subsicriptionRepository;
            _unitOfWork = unitOfWork;
            _adminsRepository = adminsRepository;
        }

        public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {

            var admin = await _adminsRepository.GetByIdAsync(request.AdminId);

            if (admin is null)
            {
                return Error.NotFound(description: "Admin not found");
            }

            var subsicription = new Subscription(
                subscriptionType: request.SubsicriptionType,
                adminId: request.AdminId
                );

            var subscription = new Subscription(
           subscriptionType: request.SubsicriptionType,
           adminId: request.AdminId);

            if (admin.SubscriptionId is not null)
            {
                return Error.Conflict(description: "Admin already has an active subscription");
            }

            admin.SetSubscription(subscription);

            await _subsicriptionRepository.AddSubsicriptionAsync(subscription);
            await _adminsRepository.UpdateAsync(admin);
            await _unitOfWork.CommitChangesAsync();

            return subscription;

        }
    }
}
