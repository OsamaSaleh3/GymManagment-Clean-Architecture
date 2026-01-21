using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Admins.Persistence;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Infrastructure.Common.Persistence;
using GymManagment.Infrastructure.Gyms.Persistence;
using GymManagment.Infrastructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<GymManagmentDbContext>(options => options.UseSqlServer("Server=OSAMA-ALMAHSERE;Database=GymManagment;Trusted_Connection=True;TrustServerCertificate=True;"));

            services.AddScoped<IAdminsRepository, AdminsRepository>();
            services.AddScoped<ISubsicriptionsRepository, SubscriptionsRepository>();
            services.AddScoped<IGymsRepository, GymsRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider=>serviceProvider.GetRequiredService<GymManagmentDbContext>());

            return services;
        }
    }
}
