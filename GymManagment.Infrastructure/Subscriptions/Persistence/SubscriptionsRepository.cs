using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using GymManagment.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly GymManagmentDbContext _dbContext;

        public SubscriptionsRepository(GymManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddSubsicriptionAsync(Subscription subsicription)
        {
            await _dbContext.Subscriptions.AddAsync(subsicription);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbContext.Subscriptions
            .AsNoTracking()
            .AnyAsync(subscription => subscription.Id == id);
        }

        public Task<Subscription?> GetByAdminIdAsync(Guid adminId)
        {
            throw new NotImplementedException();
        }

        public async Task<Subscription?>GetByIdAsync(Guid subscriptionId)
        {
            return await _dbContext.Subscriptions.FindAsync(subscriptionId);
        }

        public async Task<List<Subscription>> ListAsync()
        {
            return await _dbContext.Subscriptions.ToListAsync();
        }

        public Task RemoveSubscriptionAsync(Subscription subscription)
        {
            _dbContext.Remove(subscription);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Subscription subscription)
        {
            _dbContext.Update(subscription);

            return Task.CompletedTask;
        }
    }
}
