using Bookcrossing.Application.Configuration;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.Settings;
using Bookcrossing.Data.Configuration;
using Bookcrossing.Host.Filters;
using Bookcrossing.Host.Middleware;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Bookcrossing.Host
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
            services.AddBookcrossingData(Configuration.GetConnectionString("sqlConnection"));
            services.AddBookcrossingApplication();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            }).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            Authentication appSettings = GetAppSettings();

            AddAuthenticationSettings(services, appSettings);

            if (Configuration.GetValue<bool>("IsSwaggerEnabled"))// appSettings.IsSwaggerEnabled)
            {
                services.AddSwaggerGen(options =>
                {
                    options.SchemaFilter<CustomExcludeJsonIgnoreFilter>();
                    options.SwaggerDoc("v1", new OpenApiInfo()
                    {
                        Title = "Bookcrossing",
                        Version = "v1"
                    });

                    options.EnableAnnotations();

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                                                                          {
                                                                              {
                                                                                  new OpenApiSecurityScheme
                                                                                  {
                                                                                      Reference = new OpenApiReference
                                                                                                  {
                                                                                                      Type = ReferenceType.SecurityScheme,
                                                                                                      Id = "Bearer"
                                                                                                  },
                                                                                      Scheme = "oauth2",
                                                                                      Name = "Bearer",
                                                                                      In = ParameterLocation.Header
                                                                                  },
                                                                                  new List<string>()
                                                                              }
                                                                          });
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookcrossing v1"));
            }


            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddAuthenticationSettings(IServiceCollection services, Authentication authSettings)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = authSettings.Authority;
                        options.RequireHttpsMetadata = authSettings.RequireHttpsMetadata;
                        options.ApiName = authSettings.Audience;
                        options.SaveToken = true;
                    });
        }

        private Authentication GetAppSettings()
        {
            var appSettings = Configuration.Get<Authentication>();
            if (appSettings == null)
            {
                throw new Exception("AppSettings are missing or incorrectly configured!");
            }

            return appSettings;
        }
    }
}
