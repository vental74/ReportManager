using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportManager.Domain;

namespace ReportManager.Infrastructure.EFCore.Configuration
{
    public class ReportEntityConfiguration : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.ToTable("Reports");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Report).HasMaxLength(1000);
        }
    }
}
