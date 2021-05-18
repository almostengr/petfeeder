using Almostengr.DogFeeder.Api.Data;
using Almostengr.DogFeeder.Api.Worker;
using Almostengr.DogFeeder.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Almostengr.DogFeeder.Api
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
            AppSettings appSettings = Configuration.GetSection(nameof(appSettings)).Get<AppSettings>();
            services.AddSingleton(appSettings);

            services.AddDbContext<DogFeederDbContext>(options => 
                options.UseMySQL(appSettings.ConnectionString)
            );

            services.AddScoped<IFeedingRepository, FeedingRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            services.AddSingleton<ScheduleFeedWorker>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
