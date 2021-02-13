using AirMonitor.Client;
using AirMonitor.Core;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Measurement;
using AirMonitor.Infrastructure.Client;
using AirMonitor.Infrastructure.Service;
using AirMonitor.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AirMonitor.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Db
            string connectionString = Configuration.GetConnectionString("Development");
            AirMonitorDbContext db = InstallationPersistenceDiFactory.CreateDbContext(connectionString);
            IInstallationRepository installationRepository = InstallationPersistenceDiFactory.CreateInstallationRepository(db);
            IMeasurementRepository measurementRepository = InstallationPersistenceDiFactory.CreateMeasurementRepository(db);
            services.AddSingleton<IInstallationRepository>(installationRepository);
            services.AddSingleton<IMeasurementRepository>(measurementRepository);

            // Client
            ClientConfig clientConfig = new ClientConfig();
            Configuration.Bind("ClientConfig", clientConfig);
            IAirlyClient client = AirlyClientFactory.Create(clientConfig);
            services.AddSingleton<IAirlyClient>(client);
            services.AddSingleton<AirlyClientWrapper>();
            services.AddSingleton<IInstallationClient>(x => x.GetRequiredService<AirlyClientWrapper>());
            services.AddSingleton<IMeasurementClient>(x => x.GetRequiredService<AirlyClientWrapper>());
            
            // Service
            services.AddSingleton<IInstallationFacade, InstallationService>();
            services.AddSingleton<IMeasurementFacade, MeasurementService>();
            services.AddSingleton<IIntegrationFacade, IntegrationService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}