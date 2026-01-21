using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Gyms;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Gyms.Queries.GetGym
{
    public class GetGymQueryHandler : IRequestHandler<GetGymQuery, ErrorOr<Gym>>
    {
        private readonly IGymsRepository _gymRepository;
        private readonly ISubscriptionsRepository _subscriptionRepository;

        public GetGymQueryHandler(ISubscriptionsRepository subscriptionRepository, IGymsRepository gymRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _gymRepository = gymRepository;
        }

        public async Task<ErrorOr<Gym>> Handle(GetGymQuery Query, CancellationToken cancellationToken)
        {
            if(!await _subscriptionRepository.ExistsAsync(Query.SubscriptionId))
            {
                return Error.NotFound("Subscription not found.");
            }
            if(await _gymRepository.GetByIdAsync(Query.GymId) is not Gym gym)
            {
                return Error.NotFound("Gym not found.");
            }
            return gym;
        }
    }
}
