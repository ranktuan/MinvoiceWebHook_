
using Microsoft.AspNetCore.Mvc;
using MinvoiceWebhook.Models;
using MinvoiceWebhook.Services;



namespace MinvoiceWebhook.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class MinvoceWeHookController : ControllerBase
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;

        
        public MinvoceWeHookController(IRabbitMQConnection rabbitMQConnection)
        {
            _rabbitMQConnection = rabbitMQConnection;
        }
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(string username, string password)
        {
           
            if (IsValidUser(username, password))
            {
                var token = TokenProvider.GenerateToken(username);
                return Ok(new { token });
            }

            return Unauthorized();
        }


        
        [HttpPost]
        [Route("protected")]
        [CustomAuthorize]
        public IActionResult ProtectedEndpoint(MessageMOD messageMod)
        {
            _rabbitMQConnection.PushMessage(messageMod);

            
            return Ok("Send to Queue");
        }

        private bool IsValidUser(string username, string password)
        {
            return (username == "admin" && password == "123456");
        }
    }
}
