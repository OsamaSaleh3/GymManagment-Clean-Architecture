using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Gyms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Gyms.Queries.ListGyms
{
    public class ListGymQueryHandlerL : IRequestHandler<ListGymQuery, ErrorOr<List<Gym>>>
    {
        private readonly ISubscriptionsRepository _subscriptionRepository;
        private readonly IGymsRepository _gymRepository;

        public ListGymQueryHandlerL(ISubscriptionsRepository subscriptionRepository, IGymsRepository gymRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _gymRepository = gymRepository;
        }

        public async Task<ErrorOr<List<Gym>>> Handle(ListGymQuery Query, CancellationToken cancellationToken)
        {
            if(!await _subscriptionRepository.ExistsAsync(Query.SubscriptionId))
            {
                return Error.NotFound("Subscription NotFound");
            }
            return await _gymRepository.ListBySubscriptionIdAsync(Query.SubscriptionId);

        }
    }
}
