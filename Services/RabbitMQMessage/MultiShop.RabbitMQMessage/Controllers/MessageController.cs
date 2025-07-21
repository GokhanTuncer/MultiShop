using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection.Metadata.Ecma335;
using System.Text;

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


        private static string message;
        [HttpGet]
        public IActionResult ReadMessage()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
                
            };

            channel.BasicConsume(queue: "Kuyruk1", autoAck: true, consumer: consumer);
            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            else
            {
                return Ok("Mesaj kuyruğundan okunmuştur");
            }
            
        }
    }
}
