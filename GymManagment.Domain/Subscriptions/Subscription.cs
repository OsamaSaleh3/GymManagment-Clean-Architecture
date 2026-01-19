using GymManagment.Contracts.Subsicription;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Domain.Subscriptions
{
    public class Subscription
    {
        public Guid Id { get;}
        public SubscriptionType SubscriptionType { get; }
        public Guid AdminId { get; }

        public Subscription(SubscriptionType subscriptionType, Guid adminId, Guid? id = null)
        {
            Id = id??Guid.NewGuid();
            SubscriptionType = subscriptionType;
            AdminId = adminId;
        }

        private Subscription() { }
    }
}
