using Application;
using Application.Commands.Administradores;
using Application.Commands.Filmes;
using Application.Commands.Usuarios;
using Application.Queries.Administradores;
using Application.Queries.Filmes;
using Application.Queries.Usuarios;
using Core.Bus;
using DataAccess.Context;
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

            //Commands Filmes
            services.AddScoped<IRequestHandler<VotarFilmeCommand, bool>, FilmeCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarFilmeCommand, bool>, FilmeCommandHandler>();
            //Queries Filmes
            services.AddScoped<IFilmeQueries, FilmeQueries>();

            //Commands Usuarios
            services.AddScoped<IRequestHandler<CadastrarUsuarioCommand, bool>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<InativarUsuarioCommand, bool>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<EditarUsuarioCommand, bool>, UsuarioCommandHandler>();
            //Queries Usuarios
            services.AddScoped<IUsuarioQueries, UsuarioQueries>();

            //Commands Administradores
            services.AddScoped<IRequestHandler<CadastrarAdministradorCommand, bool>, AdministradorCommandHandler>();
            services.AddScoped<IRequestHandler<InativarAdministradorCommand, bool>, AdministradorCommandHandler>();
            services.AddScoped<IRequestHandler<EditarAdministradorCommand, bool>, AdministradorCommandHandler>();
            //Queries Administradores
            services.AddScoped<IAdministradorQueries, AdministradorQueries>();
        }
    }
}
