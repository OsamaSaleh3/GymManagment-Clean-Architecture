using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Domain.Subscriptions
{
    public class SubscriptionType:SmartEnum<SubscriptionType>
    {
        public static readonly SubscriptionType Free = new SubscriptionType("Free", 0);
        public static readonly SubscriptionType Starter = new SubscriptionType("Starter", 1);
        public static readonly SubscriptionType Pro = new SubscriptionType("Pro", 2);
        public SubscriptionType(string name, int value) : base(name, value)
        {
        }
    }
}
