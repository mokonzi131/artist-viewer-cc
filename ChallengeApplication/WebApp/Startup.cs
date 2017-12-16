using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApp.Config;

namespace WebApp
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
            services.AddMvc();

            services.AddOptions();
            services.Configure<ClientCaching>(options =>
            {
                options.CacheControlHeader = Configuration.GetValue("StaticFiles:Headers:Cache-Control", "max-age-3600");
                options.PragmaHeader = Configuration.GetValue("StaticFiles:Headers:Pragma", "cache");
                options.ExpiresHeader = Configuration.GetValue<string>("StaticFiles:Headers:Expires", null);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<ClientCaching> clientCachingOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var clientCachingConfig = clientCachingOptions.Value;
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    // Control static file caching from settings
                    context.Context.Response.Headers["Cache-Control"] = clientCachingConfig.CacheControlHeader;
                    context.Context.Response.Headers["Pragma"] = clientCachingConfig.PragmaHeader;
                    context.Context.Response.Headers["Expires"] = clientCachingConfig.ExpiresHeader;
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
