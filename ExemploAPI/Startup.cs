using ApiDocker.Infra;
using ApiDocker.Infra.Interfaces;
using ApiDocker.Infra.Repositories;
using ApiDocker.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
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

namespace ApiDocker
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
            services.AddCors(options =>
            {
                options.AddPolicy("myPolice", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.WithMethods("GET", "PUT", "DELETE", "OPTIONS", "POST", "PATCH");
                    builder.AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "(API) Exemplo",
                    Version = "v1",
                    Description = "API de Exemplo",
                    Contact = new OpenApiContact
                    {
                        Name = "Superintendencia de Gestao da Informacao (SGI-MS)",
                        Url = new Uri("http://www.sgi.ms.gov.br")
                    }
                });
                c.CustomSchemaIds(i => i.FullName);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autorizacao JWT no cabeçalho usando esquema Bearer. Exemplo: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            //Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                c.DescribeAllParametersInCamelCase();

                c.AddServer(new OpenApiServer { Url = Configuration["ServerSwagger:URL"] });
            });

            var connectionString = Configuration["ConnectionStrings:API"];

            services.AddDbContext<APIContext>(options =>
            {
                options.UseSqlServer(connectionString).UseLazyLoadingProxies();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IOrgaoRepository, OrgaoRepository>();

            services.AddScoped<IOrgaoService, OrgaoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "d0000/exemplo-api/v1/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "d0000/exemplo-api/v1/swagger";
                c.SwaggerEndpoint("/d0000/exemplo-api/v1/swagger/v1/swagger.json", "(API) Exemplo");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EXEMPLO_API v1"));
            }

            app.UseCors("myPolice");

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
