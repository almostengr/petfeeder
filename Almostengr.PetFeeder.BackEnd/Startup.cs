using Almostengr.PetFeeder.BackEnd.Services;
using Almostengr.PetFeeder.BackEnd.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Almostengr.PetFeeder.Services;
using Almostengr.PetFeeder.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Workers;
using Almostengr.PetFeeder.BackEnd.Relays;

namespace Almostengr.PetFeeder.BackEnd
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
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });

            AppSettings appSettings = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            services.AddSingleton(appSettings);

            services.AddScoped<IFeedingRelay, MockFeedingRelay>();

            services.AddScoped<IFeedingRepository, FeedingRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<ISystemSettingRepository, SystemSettingRepository>();

            services.AddScoped<IFeedingService, FeedingService>();
            services.AddScoped<IPowerService, PowerService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ISystemSettingService, SystemSettingService>();

            services.AddHostedService<ScheduleWorker>();

            services.AddDbContext<PetFeederContext>(options => options.UseSqlite($"Data Source={appSettings.DatabaseFile}"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Almostengr.PetFeeder.BackEnd", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/error");
            }

            UpdateDatabase(app);

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Almostengr.PetFeeder.BackEnd v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // perform database updates if any are available
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PetFeederContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
        
    }
}
