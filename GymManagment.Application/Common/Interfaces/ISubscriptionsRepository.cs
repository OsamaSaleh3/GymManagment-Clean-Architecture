using GymManagment.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Common.Interfaces
{
    public interface ISubscriptionsRepository
    {


        Task AddSubsicriptionAsync(Subscription subsicription);
        Task<Subscription?> GetByIdAsync(Guid id);
        Task UpdateAsync(Subscription subscription);
        Task<bool> ExistsAsync(Guid id);
        Task<Subscription?> GetByAdminIdAsync(Guid adminId);
        Task RemoveSubscriptionAsync(Subscription subscription);
        Task<List<Subscription>> ListAsync();

    }
}
