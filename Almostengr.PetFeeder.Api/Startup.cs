using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Relays;
using Almostengr.PetFeeder.Api.Repository;
using Almostengr.PetFeeder.Api.InputSensor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Almostengr.PetFeeder.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // AppSettings appSettings = Configuration.GetSection(nameof(appSettings)).Get<AppSettings>();
            // services.AddSingleton(appSettings);
            // Configuration = Configuration.GetSection("AppSettings");

            services.AddDbContext<PetFeederDbContext>(options => 
                options.UseMySQL(Configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IAlarmRepository, AlarmRepository>();
            services.AddScoped<IFeedingRepository, FeedingRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IWateringRepository, WateringRepository>();
            
            services.AddSingleton<IFoodBowlRelay, FoodBowlRelay>();
            services.AddSingleton<IWaterBowlRelay, WaterBowlRelay>();
            services.AddSingleton<INightLightRelay, NightLightRelay>();

            services.AddSingleton<IWaterInputSensor, WaterSignalInput>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
