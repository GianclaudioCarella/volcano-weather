using Infrasctructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrasctructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options) { }

        public DbSet<Year> Years { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Weather> Weathers { get; set; }



        private void YearsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Year>( y =>
            {
                y.HasKey(k => k.YearId);
                y.Property(c => c.YearId).ValueGeneratedOnAdd();
            });
        }

        private void MonthsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Month>(m =>
            {
                m.HasKey(k => k.MonthId);
                m.Property(c => c.MonthId).ValueGeneratedOnAdd();
            });
        }

        private void DaysConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>(d =>
            {
                d.HasKey(k => k.DayId);
                d.Property(c => c.DayId).ValueGeneratedOnAdd();
            });
        }

        private void WeatherConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>(w =>
            {
                w.HasKey(k => k.WeatherId);
                w.Property(c => c.WeatherId).ValueGeneratedOnAdd();
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            YearsConfiguration(modelBuilder);
            MonthsConfiguration(modelBuilder);
            DaysConfiguration(modelBuilder);
            WeatherConfiguration(modelBuilder);
        }

    }
}
