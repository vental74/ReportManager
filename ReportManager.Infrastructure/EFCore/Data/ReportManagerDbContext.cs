using Microsoft.EntityFrameworkCore;
using ReportManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Infrastructure.EFCore.Data
{
    public class ReportManagerDbContext : DbContext
    {
        public ReportManagerDbContext(DbContextOptions<ReportManagerDbContext> options):base (options)
        {
            
        }
        public virtual DbSet<ReportEntity> ReportEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //_configuration.GetConnectionString(nameof(TaskTrackerDbContext)
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=ReportManagerDb;Integrated Security=true", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
