using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtsApp.Web.ConfigModels;
using DebtsApp.Web.Database;
using DebtsApp.Web.Interfaces;
using DebtsApp.Web.Repositories;
using DebtsApp.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DebtsApp.Web
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
            ConfigureSettings(services);
            var connectionString = Configuration["ConnectionString:Database"];
            services.AddDbContext<DebtContext>(opts => opts.UseNpgsql(connectionString));
            services.AddSpaStaticFiles(config => config.RootPath = "./wwwroot");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(Configuration[$"{nameof(JwtConfig)}:{nameof(JwtConfig.SecretToken)}"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            ConfigureRepositories(services);
            ConfigureAppServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action=Index}/{id?}");
                routes.MapRoute("spa", "{*url}", new { controller = "Home", action = "Index" });
            });
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IDebtRepository, DebtRepository>();
        }

        private void ConfigureSettings(IServiceCollection services)
        {
            services.Configure<JwtConfig>(Configuration.GetSection(nameof(JwtConfig)));
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();
        }
    }
}
