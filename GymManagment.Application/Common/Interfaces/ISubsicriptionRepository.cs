using GymManagment.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Common.Interfaces
{
    public interface ISubsicriptionRepository
    {
        Task AddSubsicriptionAsync(Subscription subsicription);
    }
}
