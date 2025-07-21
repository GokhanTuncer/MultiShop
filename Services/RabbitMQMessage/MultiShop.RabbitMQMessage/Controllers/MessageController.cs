using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Reflection.Metadata.Ecma335;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk1",false,false,false,arguments: null);

            var message = "Merhaba RabbitMQ, bu bir kutuk mesajıdır";

            var byteMessageContent = System.Text.Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "Kuyruk1", basicProperties: null, body: byteMessageContent);
            return Ok("Mesajınız kuyruğa alınmıştır");
        }
    }
}
