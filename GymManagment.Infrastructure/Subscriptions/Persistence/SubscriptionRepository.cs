using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using GymManagment.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionRepository : ISubsicriptionRepository
    {
        private readonly GymManagmentDbContext _dbContext;

        public SubscriptionRepository(GymManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddSubsicriptionAsync(Subscription subsicription)
        {
            await _dbContext.subscriptions.AddAsync(subsicription);
        }

        public async Task<Subscription?>GetByIdAsync(Guid subscriptionId)
        {
            return await _dbContext.subscriptions.FindAsync(subscriptionId);
        }
    }
}
