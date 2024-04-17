using PageMonitor.Aplication.Logic.Abstractions;
using PageMonitor.Infrastructure.Persistence;
using PageMonitor.WebApi.Middlewares;
using Serilog;
using PageMonitor.Aplication;
using EasyCaching.Core;

namespace PageMonitor.WebApi
{
    public class Program
    {
        public static string APP_NAME = "PageMonitor.WebApi";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Aplication", APP_NAME)
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            if(builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddJsonFile($"appsettings.Development.local.json");
            }

            builder.Host.UseSerilog((context, services, configuration) => configuration
                .Enrich.WithProperty("Aplication", APP_NAME)
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext());



            // Add services to the container.
            builder.Services.AddDatabaseCache();
            builder.Services.AddSqlDatabase(builder.Configuration.GetConnectionString("MainDbSql")!);
            builder.Services.AddControllers();
            builder.Services.AddJwtAuth(builder.Configuration);
            builder.Services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssemblyContaining(typeof(BaseCommandHandler));
            });

            builder.Services.AddAplicationServices();
            var app = builder.Build();

            app.UseExceptionResultMiddleware();
            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
