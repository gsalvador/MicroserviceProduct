using MicroserviceProduct.DBContexts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Configuration;

namespace MicroserviceProduct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // We requieres the configuration to read config file
            var connectionString = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<MicroserviceProductContext>(options =>
                options.UseSqlServer(connectionString.Local)
            );

            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration) // Requiers Nugget Serilog.Settings.Configuration
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            builder.Services.AddCors(options => {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            var app = builder.Build();
            app.UseCors("CorsPolicy");
            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
