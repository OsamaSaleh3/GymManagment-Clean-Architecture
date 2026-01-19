using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionRepository : ISubsicriptionRepository
    {
        private readonly static List<Subscription> _subscriptions = new();
        public Task AddSubsicriptionAsync(Subscription subsicription)
        {
            _subscriptions.Add(subsicription);
            return Task.CompletedTask;
        }
    }
}
