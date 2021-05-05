using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebMVCFlashCards.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity.UI;

namespace WebMVCFlashCards
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
            string connection = Configuration.GetConnectionString("LocalConnection");
            services.AddDbContext<FlashCardsContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>(options => {
               //options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 5;   // минимальная длина
                options.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                options.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                options.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                options.Password.RequireDigit = false; // требуются ли цифры
                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz"; // допустимые символы
            }).AddEntityFrameworkStores <FlashCardsContext>();
            services.AddRazorPages();
            services.AddAuthentication().AddGoogle(options =>
            {
                //IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                options.ClientId = "525960053225-gd2g1f2bh1qjoao527mracp1lgf302hj.apps.googleusercontent.com";
                options.ClientSecret = "iRs4hQ646v9dnvDJFEEoFWGj";
            });

            services.AddControllersWithViews();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Account}/{action=Login}");
                endpoints.MapControllers();
            });
        }
    }
}
