using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shakelx.EFSimple.Core.Entities;
using Shakelx.EFSimple.Core.Interfaces;
using Shakelx.EFSimple.Infrastructure.DataBase;
using Shakelx.EFSimple.Infrastructure.Repositories;

namespace Shakelx.EFSimple.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MyDbContext>(options =>
            {
                //options.UseSqlite("data source=efsimple.db");
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<MyDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireUppercase = false;//大写
                options.Password.RequiredUniqueChars = 0;//特殊字符
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
