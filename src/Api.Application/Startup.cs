using Api.CrossCutting.AutoMapper;
using Api.CrossCutting.Ioc;
using Api.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace Api.Application
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
            services.AddHealthChecks();
            services.AddMediatR(typeof(Startup));
            services.RegisterMappers();

            services.Configure<MongoDbConfig>(Configuration.GetSection("ConnectionStringMongo"));

            services.AddSingleton<IMongoDbConfig>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbConfig>>().Value);

            IocBootstrapper.RegisterServices(services, Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Cesta 2 Irmãos",
                    Description = "Api desenvolvida, aplicando conhecimento apreendido.",
                    TermsOfService = new Uri("https://romulo-moreschi.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Romulo Moreschi Filho",
                        Email = "romulo_moreschi@hotmail.com",
                        Url = new Uri("https://romulo-moreschi.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("https://romulo-moreschi.com")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api.Application v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseHealthChecks("/check");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
