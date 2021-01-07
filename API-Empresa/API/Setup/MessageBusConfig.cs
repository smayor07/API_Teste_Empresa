using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MessageBus;
using Core.Utils;

namespace API.Setup
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));

        }
    }
}
