using Microsoft.EntityFrameworkCore;
using GymManagment.Domain.Admins;
namespace GymManagment.Infrastructure.Admins.Persistence;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Admin> builder)
    {
        builder.HasData(new Admin(
           userId: Guid.Parse("3350e333-8fdc-42a3-9474-1a3956d46de8"),
           id: Guid.Parse("2150e333-8fdc-42a3-9474-1a3956d46de8")));
    }
}
