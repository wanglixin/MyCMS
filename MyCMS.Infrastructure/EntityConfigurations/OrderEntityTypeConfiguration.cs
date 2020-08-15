
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Domain.SiteAggregate;

namespace MyCMS.Infrastructure.EntityConfigurations
{
    class SiteInfoEntityTypeConfiguration : IEntityTypeConfiguration<SiteInfo>
    {
        public void Configure(EntityTypeBuilder<SiteInfo> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("SiteInfo");
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Domain).HasMaxLength(200);
            builder.Property(p => p.Desc).HasMaxLength(1000);
            //builder.OwnsOne(o => o.Address, a =>
            //{
            //    a.WithOwner();
            //    a.Property(p => p.City).HasMaxLength(20);
            //    a.Property(p => p.Street).HasMaxLength(50);
            //    a.Property(p => p.ZipCode).HasMaxLength(10);
            //});
        }
    }
}
