using AccountOwnerServer.Extensions;
using ClubsCore.Mapping;
using ClubsCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.IO;
using System.Reflection;

namespace ClubsCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/log.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            services.AddDbContext<ClubsContext>(
              dbContextOptions => dbContextOptions
                  .UseMySql(Configuration["ConnectionString:ClubsDb"], serverVersion)
                  .EnableSensitiveDataLogging()
                  .EnableDetailedErrors()
          );
            services.AddDbContext<ClubsContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ClubsDb"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "Hello There",
                    Contact = new OpenApiContact
                    {
                        Name = "It actually works",
                        Email = string.Empty,
                    },
                    License = new OpenApiLicense
                    {
                        Name = "WTF am doing here 3am",
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSingleton(sp => MapperInitializer.GetMapper());

            services.AddControllers();

            services.AddSwaggerGen();

            services.ConfigureCors();

            services.ConfigureIISIntegration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}