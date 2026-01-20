using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using GymManagment.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionsRepository : ISubsicriptionsRepository
    {
        private readonly GymManagmentDbContext _dbContext;

        public SubscriptionsRepository(GymManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddSubsicriptionAsync(Subscription subsicription)
        {
            await _dbContext.subscriptions.AddAsync(subsicription);
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Subscription?>GetByIdAsync(Guid subscriptionId)
        {
            return await _dbContext.subscriptions.FindAsync(subscriptionId);
        }

        public Task UpdateAsync(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
