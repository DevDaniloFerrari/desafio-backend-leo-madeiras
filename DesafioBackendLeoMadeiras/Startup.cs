using DesafioBackendLeoMadeiras.API.Configurations;
using DesafioBackendLeoMadeiras.Domain.Handlers;
using DesafioBackendLeoMadeiras.Domain.Repositories;
using DesafioBackendLeoMadeiras.Domain.Services;
using DesafioBackendLeoMadeiras.Infra.Repositories;
using DesafioBackendLeoMadeiras.Infra.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace DesafioBackendLeoMadeiras
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerConfiguration();
            services.AddTokenConfiguration();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ValidarUsuarioCommandHandler>();
            services.AddScoped<ValidarSenhaCommandHandler>();
            services.AddMediatR(typeof(ValidarUsuarioCommandHandler).GetTypeInfo().Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfiguration();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
