using Microsoft.EntityFrameworkCore;
//using ReportManager.Application.Mapper;
using ReportManager.Application.Services;
using ReportManager.Domain;
using ReportManager.Domain.Interfaces;
using ReportManager.Infrastructure.EFCore.Data;
using ReportManager.Infrastructure.Repositories;
using AutoMapper;
using ReportManager.Api.BackgroundJobs;
using ReportManager.Api.Middleware;
using ReportManager.Infrastructure.Cache;
using ReportManager.Application.Utilities;

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
            //RegisterDbLayer(builder.Services);
            builder.Services.AddTransient<Domain.Interfaces.IMapper, Application.Mapper.FirstMapper>();
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Application.Mapper.AutoMapperConfiguration>();
            });
            builder.Services.AddTransient(x => autoMapperConfig.CreateMapper());
            var DbContexOptionsBuilder = new DbContextOptionsBuilder<ReportManagerDbContext>();
            builder.Services.AddTransient<ReportManagerDbContext>(x =>new ReportManagerDbContext(DbContexOptionsBuilder.Options));
            builder.Services.AddTransient(typeof(ReportService));
            builder.Services.AddSingleton<ICache<ReportEntity>, FirstMemoryCache<ReportEntity>>();
            builder.Services.AddSingleton<Domain.Interfaces.ILogger, FirstLogger>();
            //builder.Services.AddHostedService<CreatingReportJob>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

           
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.UseMiddleware<MiddlewareException>();
            app.UseMiddleware<MiddlewareRequestLogger>();
            app.Run();

        }

        //private static void RegisterDbLayer(IServiceCollection services)
        //{
        //    services.AddTransient<ICreateRepository<ReportEntity>, EFCreateRepository<ReportEntity>>();
        //    services.AddTransient<IUpdateRepository<ReportEntity>, EFUpdateRepository<ReportEntity>>();
        //    services.AddTransient<IDeleteRepository<ReportEntity>, EFDeleteRepository<ReportEntity>>();
        //    services.AddTransient<IGetRepository<ReportEntity>, EFGetRepository<ReportEntity>>();
        //}
    }
}