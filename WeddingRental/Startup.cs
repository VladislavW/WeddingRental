using System;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WeddingRental.Configurations;
using WeddingRental.Extensions;
using WeddingRental.Filters;
using WeddingRental.Models.Views.User;

namespace WeddingRental
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
            
            var dbConnectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDataInfrastructure(dbConnectionString);
            services.AddRepositories();
            services.AddServices();
            services.AddUnitOfWorks();
            services.AddAutoMapper();
            services.AddSingleton(Configuration);

            
            var jwtConfigurations = new JwtProviderConfiguration
            {
                Issuer = Configuration["Jwt:Issuer"],
                Audience = Configuration["Jwt:Audience"],
                SecretKey = Configuration["Jwt:SecretKey"]
            };

            services.Configure<JwtProviderConfiguration>(options =>
            {
                options.Issuer = jwtConfigurations.Issuer;
                options.Audience = jwtConfigurations.Audience;
                options.SecretKey = jwtConfigurations.SecretKey;
            });
            
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfigurations.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtConfigurations.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = jwtConfigurations.GetSecurityKey(),
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
                
            services
                .AddMvc(options =>
                {
                    var policy = new AuthorizationPolicyBuilder(
                            JwtBearerDefaults.AuthenticationScheme,
                            IdentityConstants.ApplicationScheme)
                        .RequireAuthenticatedUser()
                        .Build();

                    options.Filters.Add(new AuthorizeFilter(policy));
                    options.Filters.Add(new ExceptionHandlerAttribute());
                })
                .AddFluentValidation(fv =>   
                {  
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>(); 
                });  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //routes.MapRoute("adminAreaRoute", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

//                routes.MapSpaFallbackRoute(
//                    name: "spa-fallback",
//                    defaults: new { controller = "Home", action = "Index" });
                
                routes.MapRoute(
                    name: "spa-fallback",
                    template: "{*.}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index",
                    }
                );
            });
        }
    }
}
