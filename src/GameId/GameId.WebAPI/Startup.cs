using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameId.Domain.Bizoffer.Interface;
using GameId.Domain.Interface;
using GameId.Domain.Order;
using GameId.Domain.Order.Interface;
using GameId.Infrastructure;
using GameId.Infrastructure.Gateway;
using GameId.Infrastructure.Repository;
using GameId.Service;
using GameId.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using MediatR;

namespace GameId.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMediatR();
            services.AddHttpClient();
            services.AddScoped<IBizofferAppService, BizofferAppService>();
            services.AddScoped<IBizofferRepository, BizofferRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IPlaceOrderService, PlaceOrderService>();
            services.AddScoped<ISecurityService, SecurityServiceClient>();
            services.AddScoped<IBizofferService, BizofferServiceClient>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContextPool<GameId.Infrastructure.AppContext>(options =>
            {
                options.UseMyCat("server=127.0.0.1; port=8066; uid=root; pwd=123456; database=blog");
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
