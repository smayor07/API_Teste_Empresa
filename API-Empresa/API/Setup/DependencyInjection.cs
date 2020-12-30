using Application;
using Application.Commands.Filmes;
using Core.Bus;
using DataAccess.Repositories;
using Entity.Interfaces.Application;
using Entity.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
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
        }
    }
}
