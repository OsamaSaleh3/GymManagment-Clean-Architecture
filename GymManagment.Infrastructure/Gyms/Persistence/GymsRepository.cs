using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Gyms;
using GymManagment.Infrastructure.Common.Persistence;
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

        public Task AddGymAsync(Gym gym)
        {
            throw new NotImplementedException();
        }

        public Task<Gym?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gym>> ListBySubscriptionIdAsync(Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveGymAsync(Gym gym)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGymAsync(Gym gym)
        {
            throw new NotImplementedException();
        }
    }
}
