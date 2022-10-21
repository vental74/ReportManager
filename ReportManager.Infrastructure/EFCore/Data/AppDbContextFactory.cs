using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Infrastructure.EFCore.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ReportManagerDbContext>
    {
        public ReportManagerDbContext CreateDbContext(string[] args)
        {
            //var builder = new ConfigurationBuilder()
            //           .SetBasePath(Directory.GetCurrentDirectory())
            //           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //           .AddEnvironmentVariables();

            //IConfigurationRoot configuration = builder.Build();
            //string connectionString = configuration.GetConnectionString(nameof(ReportManagerDbContext));
            var optionsBuilder = new DbContextOptionsBuilder<ReportManagerDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=ReportManagerDb;Integrated Security=true");

            return new ReportManagerDbContext(optionsBuilder.Options);
        }
    }
}
