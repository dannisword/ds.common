using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using Microsoft.OpenApi.Models;
using AutoMapper;

using DS.Common.Entities;
using DS.Repository.Db;
using DS.Repository.Infrastructure;
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
            services.AddControllers()
            .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            var connection = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, SQLContext>();

            //Services
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //this.addRepositoriesScoped(services);
            this.configureAPIDocument(services);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    this.Configuration.GetSection("Swagger:Title").Value
                );
            });

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

        private void configureAPIDocument(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents app
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = this.Configuration.GetSection("Swagger:Title").Value,
                    Version = "v1"
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{AppDomain.CurrentDomain.FriendlyName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
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
                        Console.WriteLine(type.FullName);
                        //services.AddScoped<IRepository<Order>, Repository<Order>>();
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

    }
}
