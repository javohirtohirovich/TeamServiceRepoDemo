using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NTierApplication.DataAccess.Models;

namespace NTierApplication.DataAccess.Map;

internal class UserMap : IEntityTypeConfiguration<User>
{ 
    public void Configure(EntityTypeBuilder<User> builder)
    {
    builder.ToTable("User");
    builder.Property(t => t.CreatedAt).HasColumnType("datetime2");
    }
}
