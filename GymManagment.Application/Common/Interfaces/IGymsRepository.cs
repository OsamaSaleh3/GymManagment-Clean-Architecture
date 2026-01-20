using GymManagment.Domain.Gyms;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Common.Interfaces
{
    public interface IGymsRepository
    {
        Task<Gym?> GetByIdAsync(Guid id);
        Task UpdateGymAsync(Gym gym);
        Task AddGymAsync(Gym gym);
        Task RemoveGymAsync(Gym gym);
        Task<List<Gym>> ListBySubscriptionIdAsync(Guid subscriptionId);
    }
}
