
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Domain.SiteAggregate;

namespace MyCMS.Infrastructure.EntityConfigurations
{
    class SiteInfoEntityTypeConfiguration : BaseEntityTypeConfiguration<SiteInfo, int>
    {
        public override void Configure(EntityTypeBuilder<SiteInfo> builder)
        {
            base.Configure(builder);
            builder.ToTable("SiteInfo");
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Domain).HasMaxLength(200);
            builder.Property(p => p.Desc).HasMaxLength(1000);

        }
    }
}
