using Application;
using Application.Commands.Filmes;
using Core.Bus;
using DataAccess.Context;
using DataAccess.Repositories;
using Entity.Interfaces.Application;
using Entity.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
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

            //Context
            services.AddDbContext<APIDbContext>();

            //Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Applications
            services.AddScoped<IAdministradorApplication, AdministradorApplication>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IFilmeApplication, FilmeApplication>();

            //Repositories
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();

            //Commands
            services.AddScoped<IRequestHandler<VotarFilmeCommand, bool>, FilmeCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarFilmeCommand, bool>, FilmeCommandHandler>();

            services.AddMediatR(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API-Teste Empresa", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
