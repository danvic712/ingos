using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Ingos.API
{
    /// <summary>
    /// Application start up configuration
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<IngosApiModule>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeApplication();
        }
    }
}