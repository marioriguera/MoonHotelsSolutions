using MoonHotels.Hub.Api.Config;
using MoonHotels.Hub.Api.Hub;

namespace MoonHotels.Hub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            NlogConfigurator.Initialize();
            NlogConfigurator.AddConsole();
            NlogConfigurator.AddDebugger();
            NlogConfigurator.Start();

            try
            {
                // Apply configs
                NlogConfigurator.ApplyConfigurationToLogs();

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.ConfigureSwaggerGen();

                builder.Services.AddSignalR();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.MapHub<MoonHotelsHub>("search-hub");

                app.UseAuthorization();


                app.MapControllers();


                ApiConfigurationService.Current.Logger.Fatal($"The API will start.");
                app.Run();
            }
            catch (Exception ex)
            {
                // NLog: catch setup errors
                ApiConfigurationService.Current.Logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
