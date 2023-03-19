using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Wells_WebAPI.Data.Models;

namespace Wells_WebAPI.Persistence.Database
{
    public class HolePointsConfgiguration : IEntityTypeConfiguration<HolePoints>
    {
        public void Configure(EntityTypeBuilder<HolePoints> builder)
        {
            builder
                .HasOne(hp => hp.Hole)
                .WithMany(h => h.HolePoints)
                .HasForeignKey(hp => hp.HoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class DrillBlockPointsConfgiguration : IEntityTypeConfiguration<DrillBlockPoints>
    {
        public void Configure(EntityTypeBuilder<DrillBlockPoints> builder)
        {
            builder
                .HasOne(dbp => dbp.DrillBlock)
                .WithMany(db => db.DrillBlockPoints)
                .HasForeignKey(dbp => dbp.DrillBlockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class DrillBlockConfgiguration : IEntityTypeConfiguration<DrillBlock>
    {
        public void Configure(EntityTypeBuilder<DrillBlock> builder)
        {
            builder
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }

    public class HoleConfgiguration : IEntityTypeConfiguration<Hole>
    {
        public void Configure(EntityTypeBuilder<Hole> builder)
        {
            builder
                 .Property(e => e.Name)
                 .HasMaxLength(50)
                 .IsRequired();
            builder
                .HasOne(h => h.DrillBlock)
                .WithMany(db => db.Holes)
                .HasForeignKey(h => h.DrillBlockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
