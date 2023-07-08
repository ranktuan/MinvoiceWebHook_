
using MinvoiceWebhook.Models;
using RabbitMQ.Client;


namespace MinvoiceWebhook.Services
{
    public interface IRabbitMQConnection
    {
        IConnection CreateConnection();
        void PushMessage(MessageMOD message);

        
    }
    public interface ITokenService
    {
        string GenerateToken(string username, string password);
    }


}
