using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyIdentityServer.FirstClient
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

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies"; // isimlendirme �nemli de�il
                options.DefaultChallengeScheme = "oidc"; // isimlendirme �nemli de�il
            }).AddCookie("Cookies").AddOpenIdConnect("oidc", opts =>
            {
                opts.SignInScheme = "Cookies";// kullan�c�n�n login olmas� i�in default �emay� burada tekrar veriyoruz
                opts.Authority = "https://localhost:5001";//token da��tan adres
                opts.ClientId = "clientMvc";
                opts.ClientSecret = "secret";
                opts.ResponseType = "code id_token"; // code -> access token almak i�in id_token-> token do�ru yerden mi gelmi� diye kontrol etmek i�in
                opts.GetClaimsFromUserInfoEndpoint = true;// Kullan�c� hakk�nda ek claimleri elde ediyoruz
                opts.SaveTokens = true; // access ve refresh token varsa kaydedilir.
                opts.Scope.Add("firstApi.read"); // bana bu scope'u da ver
                opts.Scope.Add("offline_access"); // bana bu scope'u da ver
                opts.Scope.Add("CountryAndCity"); // bana bu scope'u da ver

                opts.ClaimActions.MapUniqueJsonKey("country", "country");// 2. parametre config i�erisinde tan�mlad���m�z de�eri 
                opts.ClaimActions.MapUniqueJsonKey("city", "city");// 2. parametre config i�erisinde tan�mlad���m�z de�eri 
            });// addcookie addopenidconnect -> yukar�da verdi�imiz scheme adlar� ile ayn� olmal� 


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
            app.UseAuthentication();
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
