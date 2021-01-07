using Microsoft.Extensions.Configuration;

namespace Core.Utils
{
    public static class ConfigurationExtensios
    {
        public static string GetMessageQueueConnection(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("MessageQueueConnection")?[name];
        }
    }
}
