using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Gyms;
using GymManagment.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Infrastructure.Gyms.Persistence
{
    public class GymsRepository : IGymsRepository
    {
        private readonly GymManagmentDbContext _dbContext;

        public GymsRepository(GymManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddGymAsync(Gym gym)
        {
            await _dbContext.Gyms.AddAsync(gym);
        }

        public async Task<Gym?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Gyms.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Gym>> ListBySubscriptionIdAsync(Guid subscriptionId)
        {
            return await _dbContext.Gyms
                .Where(g => g.SubscriptionId == subscriptionId)
                .ToListAsync();
        }

        public Task RemoveGymAsync(Gym gym)
        {
            _dbContext.Gyms.Remove(gym);
            return Task.CompletedTask;
        }

        public Task RemoveRangeAsync(List<Gym> gyms)
        {
            _dbContext.RemoveRange(gyms);

            return Task.CompletedTask;
        }

        public Task UpdateGymAsync(Gym gym)
        {
             _dbContext.Update(gym);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbContext.Gyms.AsNoTracking().AnyAsync(gym => gym.Id == id);
        }
    }
}
