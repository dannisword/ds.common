using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using DS.Common.Entities;
using DS.Repository.Db;
using DS.Repository.Implement;
using DS.Repository.Infrastructure;
using DS.Repository.Interface;
using DS.Services.Implement;
using DS.Services.Interface;

namespace DS.Webapi
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
            services.AddControllers();

            var connection = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BloggingContext>(
                         options => options.UseSqlServer(connection));

            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, BloggingContext>();

            //Repoistories
            //services.AddScoped<IRepository<Order>, Repository<Order>>();
            //services.AddScoped<IRepository<OrderDetail>, Repository<OrderDetail>>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Services
            services.AddScoped<IOrderService, OrderService>();



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



        }
        private void addRepositoriesScoped(IServiceCollection services)
        {
            //載入組件
            Assembly assembly = Assembly.Load("DS.Common");

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    if (type.FullName.Contains("DS.Common.Entities") == true)
                    {
                        //Console.WriteLine(type.FullName);
                        services.AddScoped<IRepository<Order>, Repository<Order>>();
                    }
                }
            }
        }

        /// <summary>
        /// 介面
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Type> GetInterfaces()
        {
            Assembly assembly = Assembly.Load("DS.Repository");

            var q = from a in assembly.GetTypes()
                    where a.FullName.Contains("DS.Repository.Interface") &&
                          a.IsInterface == true
                    select a;
            return q.ToList();
        }

        /// <summary>
        /// 實作
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Type> GetImplements()
        {
            Assembly assembly = Assembly.Load("DS.Repository");

            var q = from a in assembly.GetTypes()
                    where a.FullName.Contains("DS.Repository.Implement") &&
                          a.IsClass == true
                    select a;


            return q.ToList();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
