using GymManagment.Application.Common.Interfaces;
using GymManagment.Infrastructure.Subscriptions.Persistence;
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
            services.AddScoped<ISubsicriptionRepository, SubscriptionRepository>();
            return services;
        }
    }
}
