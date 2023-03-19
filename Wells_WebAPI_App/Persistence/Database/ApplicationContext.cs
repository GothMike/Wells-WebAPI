using Microsoft.EntityFrameworkCore;
using Wells_WebAPI.Data.Models;

namespace Wells_WebAPI.Persistence.Database
{
    public class ApplicationContext : DbContext
    {
        internal readonly object dbSet;

        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<DrillBlockPoints> DrillBlockPoints { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HolePoints> HolePoints { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HolePointsConfgiguration());
            modelBuilder.ApplyConfiguration(new DrillBlockPointsConfgiguration());
            modelBuilder.ApplyConfiguration(new DrillBlockConfgiguration());
            modelBuilder.ApplyConfiguration(new HoleConfgiguration());
        }
    }
}
