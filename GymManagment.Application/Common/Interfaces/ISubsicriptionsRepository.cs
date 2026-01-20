using GymManagment.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Common.Interfaces
{
    public interface ISubsicriptionsRepository
    {
        Task AddSubsicriptionAsync(Subscription subsicription);
        Task<Subscription> GetByIdAsync(Guid subscriptionId);
        Task UpdateAsync(Subscription subscription);
        Task<bool> ExistsAsync(Guid id);


    }
}
