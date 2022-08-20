using AutoMapper;
using Manager.Core.ApplicationService.Config;
using Manager.Core.ApplicationService.Facade;
using Manager.Core.ApplicationService.UnitOfWork;
using Manager.Core.Contracts.Facade;
using Manager.Core.Contracts.Repository;
using Manager.Core.Contracts.Repository.Common;
using Manager.Core.Contracts.UnitOfWork;
using Manager.Infrastructure.Data.Common;
using Manager.Infrastructure.Data.Repository;
using Manager.Infrastructure.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationHost
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
            services.AddControllersWithViews();
            services.AddDbContext<ManagerContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("ManagerDB"));

            });
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductProfile());
                mc.AddProfile(new FactorProfile());
                mc.AddProfile(new StoreProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUnitOfWork, UnitofWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IFactorRepository, FactorRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IProductFacade, ProductsFacade>();
            services.AddScoped<IFactorFacade, FactorFacade>();
            services.AddScoped<IStoreFacade, StoreFacade    >();
            services.AddScoped<IGenericRepository<IProductRepository>, GenericRepository<IProductRepository>>();
            services.AddScoped<IGenericRepository<IFactorRepository>, GenericRepository<IFactorRepository>>();
            services.AddScoped<IGenericRepository<IStoreRepository>, GenericRepository<IStoreRepository>>();

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
