using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ApiGestion.Models;

namespace ApiGestion.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<ModelsContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("MyConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<ModelsContext>();


            services.AddControllers();
            services.AddCors();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }
    }
}
