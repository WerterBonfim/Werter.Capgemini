using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Werter.Capgemini.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Werter - Teste para Capgemini",
                    Description = "Esta API faz parte do teste da Capgemini",
                    Contact = new OpenApiContact {Name = "Werter Bonfim", Email = "werter@hotmail.com.br"},
                    License = new OpenApiLicense {Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT")} 
                });
            });

            return services;
        }
        
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });

            return app;
        }
    }
}