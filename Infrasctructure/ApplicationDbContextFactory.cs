using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrasctructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private const string CONNECTIONSTRING = @"server=(LocalDB)\MSSQLLocalDB;database=VolcanoWeather;AttachDbFilename=.\\VolcanoWeather.mdf;trusted_connection=True";

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var ctor = new DbContextOptionsBuilder<ApplicationDbContext>();
            ctor.UseSqlServer(CONNECTIONSTRING);
            return new ApplicationDbContext(ctor.Options);
        }
    }
}
