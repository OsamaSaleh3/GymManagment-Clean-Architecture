using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Domain.Subscriptions
{
    public class Subscription
    {
        public Guid Id { get; set; }= Guid.NewGuid();
    }
}
