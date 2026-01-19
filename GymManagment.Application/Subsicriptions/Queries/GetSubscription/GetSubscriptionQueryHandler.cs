using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Subsicriptions.Queries.GetSubscription
{
    public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
    {
        private readonly ISubsicriptionRepository _subsicriptionRepository;

        public GetSubscriptionQueryHandler(ISubsicriptionRepository subsicriptionRepository)
        {
            _subsicriptionRepository = subsicriptionRepository;
        }

        public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscription = await _subsicriptionRepository.GetByIdAsync(request.SubscriptionId);
            return subscription is null ? Error.NotFound(description: "Subscription Not Found"): subscription;
        }
    }
}
