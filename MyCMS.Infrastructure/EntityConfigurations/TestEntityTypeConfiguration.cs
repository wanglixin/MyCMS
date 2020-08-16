using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Infrastructure.EntityConfigurations
{
    class TestEntityTypeConfiguration : BaseEntityTypeConfiguration<Test, string>
    {
        public override void Configure(EntityTypeBuilder<Test> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Id).HasMaxLength(50);
            builder.ToTable("Test");
            builder.Property(p => p.Name).HasMaxLength(100);
        }
    }
}
