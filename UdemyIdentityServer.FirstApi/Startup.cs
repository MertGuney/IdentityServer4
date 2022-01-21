using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyIdentityServer.FirstApi
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
            // ilk kýsýmda verdiðimiz isimle ikinci kýsýmdaki ayný olmalý cünkü birbirlerini tanýmalarý icin
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = "https://localhost:5001"; //access token nereden yayýnlanýyor ?
                options.Audience = "resource_firstApi"; // gelen tokenin aud alanýnda ne olucak ?
            });

            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("ReadProduct", policy =>
                {
                    policy.RequireClaim("scope", "firstApi.read");//yetkilendirme alanlarý kime ait -> scope yetki nedir ilk api okuma
                });
                opts.AddPolicy("UpdateOrCreate", policy =>
                {
                    policy.RequireClaim("scope", new[] { "firstApi.update", "firstApi.write" });
                });
            });

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
