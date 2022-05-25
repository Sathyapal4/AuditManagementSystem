using Amazon.Util.Internal.PlatformServices;
using AuditManagementPortal.Models;
using AuditManagementPortal.Providers;
using AuditManagementPortal.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal
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
            //Inject Settings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddControllersWithViews();
            services.AddSwaggerGen();
            services.AddDbContext<AuditDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            
            services.AddMemoryCache();
            services.AddSession();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuditChecklistProvider, AuditChecklistProvider>();
            services.AddScoped<IAuditChecklistRepository, AuditChecklistRepository>();
            services.AddScoped<IAuditLoginProvider, AuditLoginProvider>();
            services.AddScoped<IAuditLoginRepository, AuditLoginRepository>();
            services.AddScoped<IAuditSeverityProvider, AuditSeverityProvider>();
            services.AddScoped<IAuditSeverityRepository, AuditSeverityRepository>();
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Home", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Home");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });
            //Add JWToken Authentication service


            //app.UseCors(builder =>
            //builder.WithOrigins("http://localhost:4200")
            //.AllowAnyOrigin()
            //.AllowAnyHeader()
            //.AllowAnyMethod());

            app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

            //app.UseMvc();

            app.UseAuthentication();

            //app.UseCookiePolicy();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Login}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
