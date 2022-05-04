using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Infrastructure.Data.Maps
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar");
            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");
            builder.Property(s => s.CorporateName)
                .HasMaxLength(100)
                .HasColumnType("varchar");
            builder.Property(s => s.Phone)
                .HasMaxLength(12)
                .HasColumnType("varchar");
            builder.Property(s => s.Contact)
                .HasMaxLength(50)
                .HasColumnType("varchar");
            builder.Property(s => s.Active)
                .IsRequired()
                .HasColumnType("bit");
            builder.Property(s => s.RegistrationDate)
                .HasColumnType("date");
            builder.OwnsOne(s => s.Email, email =>
            {
                email.Property(e => e.EmailAddress).IsRequired();
            });
            builder.OwnsOne(s => s.Document, doc =>
            {
                doc.Property(d => d.Type)
                    .IsRequired()
                    .HasColumnType("int");
                doc.Property(d => d.Number)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnType("varchar");
            });
            builder.OwnsOne(s => s.Address, address =>
            {
                address.Property(a => a.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");
                address.Property(a => a.Number)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("varchar");
                address.Property(a => a.Neighborhood)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");
                address.Property(a => a.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("varchar");
                address.Property(a => a.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");
                address.Property(a => a.ZipCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnType("varchar");
            });
        }
    }
}
