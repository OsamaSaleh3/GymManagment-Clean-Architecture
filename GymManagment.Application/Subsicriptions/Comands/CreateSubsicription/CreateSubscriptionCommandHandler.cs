using ErrorOr;
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

        private readonly ISubsicriptionRepository _subsicriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubscriptionCommandHandler(ISubsicriptionRepository subsicriptionRepository, IUnitOfWork unitOfWork)
        {
            _subsicriptionRepository = subsicriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subsicription = new Subscription(
                subscriptionType: request.SubsicriptionType,
                adminId: request.AdminId
                );

            await _subsicriptionRepository.AddSubsicriptionAsync(subsicription);
           await _unitOfWork.CommitChangesAsync();
            return subsicription;

        }
    }
}
