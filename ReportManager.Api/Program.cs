using Microsoft.EntityFrameworkCore;
using ReportManager.Application.Services;
using ReportManager.Domain;
using ReportManager.Domain.Interfaces;
using ReportManager.Infrastructure.EFCore.Data;
using ReportManager.Infrastructure.Repositories;

namespace ReportManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IRepository<ReportEntity>, EFRepository<ReportEntity>>();
            var DbContexOptionsBuilder = new DbContextOptionsBuilder<ReportManagerDbContext>();
            builder.Services.AddTransient<ReportManagerDbContext>(x =>new ReportManagerDbContext(DbContexOptionsBuilder.Options));
            builder.Services.AddTransient(typeof(ReportService));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
          
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}