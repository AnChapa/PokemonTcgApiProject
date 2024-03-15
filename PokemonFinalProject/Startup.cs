using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using PokemonFinalProject.Service;

namespace PokemonFinalProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddHttpClient(); // Register HttpClient
            //services.AddScoped<CardRetrieval>(); // Register CardService
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=SetView}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=PokemonAPI}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "card",
                    pattern: "PokemonAPI/Card/{id}",
                    defaults: new { controller = "PokemonAPI", action = "CardDetails" });
            });
        }
    }
}
