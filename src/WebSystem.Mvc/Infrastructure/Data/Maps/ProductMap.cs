using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Infrastructure.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar");
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal");
            builder.Property(p => p.Image)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.Property(p => p.RegistrationDate)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(p => p.Active)
                .IsRequired()
                .HasColumnType("bit");
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }
}
