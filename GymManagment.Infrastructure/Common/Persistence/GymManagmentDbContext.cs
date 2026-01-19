using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Infrastructure.Common.Persistence
{
    public class GymManagmentDbContext:DbContext,IUnitOfWork
    {
        public DbSet<Subscription> subscriptions { get; set; } = null!;

        public GymManagmentDbContext(DbContextOptions options):base(options)
        {

        }

        public async Task CommitChangesAsync()
        {
           await base.SaveChangesAsync();
        }
    }
}
