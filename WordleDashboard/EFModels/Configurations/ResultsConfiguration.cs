using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using WordleDashboard.EFModels;

namespace WorldeDashboard.EFModels.Configurations
{
    public class ResultsConfiguration : IEntityTypeConfiguration<Result>
    {
        void IEntityTypeConfiguration<Result>.Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("Results");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Gkey).HasDefaultValueSql("(newid())");
        }
    }
}
