using Domain.VolcanoContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.VolcanoContext.DataContexts
{
    public class VolcanoDbContext : DbContext
    {
        public VolcanoDbContext()
        {

        }

        public VolcanoDbContext(DbContextOptions<VolcanoDbContext> options) 
            :base(options) { }

        public DbSet<Weather> Weathers { get; set; }

        private void WeatherConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>(w =>
            {
                w.HasKey(k => k.Id);
                w.Property(c => c.Id).ValueGeneratedOnAdd();
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            WeatherConfiguration(modelBuilder);
        }

    }
}
