
using GymManagement.Application.Common.Interfaces;
using GymManagment.Domain.Admins;
using GymManagment.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Admins.Persistence;

public class AdminsRepository(GymManagmentDbContext dbContext) : IAdminsRepository
{
    private readonly GymManagmentDbContext _dbContext = dbContext;

    public Task<Admin?> GetByIdAsync(Guid adminId)
    {
        return _dbContext.Admins.FirstOrDefaultAsync(a => a.Id == adminId);
    }

    public Task UpdateAsync(Admin admin)
    {
        _dbContext.Admins.Update(admin);

        return Task.CompletedTask;
    }
}