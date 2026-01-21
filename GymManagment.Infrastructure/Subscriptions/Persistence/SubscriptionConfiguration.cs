using GymManagment.Domain.Subscriptions;
using GymManagment.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Infrastructure.Subscriptions.Persistence
{
    internal class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedNever();

        builder.Property("_maxGyms")
            .HasColumnName("MaxGyms");

        builder.Property(s => s.AdminId);

        builder.Property(s => s.SubscriptionType)
            .HasConversion(
                subscriptionType => subscriptionType.Name,
                value => SubscriptionType.FromName(value));

        builder.Property<List<Guid>>("_gymIds")
            .HasColumnName("GymIds")
            .HasListOfIdsConverter();

        }
    }
}

