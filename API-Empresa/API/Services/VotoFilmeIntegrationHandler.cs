using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Filmes;
using Core.Bus;
using Core.Integration;
using Core.Integration.Filmes;
using MessageBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Services
{
    public class VotoFilmeIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _messageBus;
        private readonly IServiceProvider _serviceProvider;

        public VotoFilmeIntegrationHandler(IServiceProvider serviceProvider, IMessageBus messageBus)
        {
            _serviceProvider = serviceProvider;
            _messageBus = messageBus;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _messageBus.RespondAsync<VotoFilmeIntegrationEvent, ResponseMessage>(async request =>
                new ResponseMessage(await VotarFilme(request)));

            return Task.CompletedTask;
        }

        private async Task<bool> VotarFilme(VotoFilmeIntegrationEvent message)
        {
            var filmeCommand = new VotarFilmeCommand(message.FilmeId, message.Votos);
            bool sucesso = false;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(filmeCommand);
            }

            return sucesso;
        }
    }
}