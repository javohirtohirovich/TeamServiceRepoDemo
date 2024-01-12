using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierApplication.DataAccess.Models;

namespace NTierApplication.DataAccess.Map;

internal class ItemMap : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Item");

        builder.Property(t => t.ItemDate).HasColumnType("datetime2");
        builder.Property(t => t.ItemType).HasColumnType("int").IsRequired();

    }
}
