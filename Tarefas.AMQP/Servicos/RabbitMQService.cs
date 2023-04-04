using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;
using Tarefas.Model.Models;

namespace Tarefas.AMQP.Servicos
{
    public class RabbitMQService : IRabbitMQService
    {
        private const string _queueName = "tarefas";
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {

            
            
            var body = Encoding.UTF8.GetBytes("Ola rabitt");

            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();



            _channel.QueueDeclare(queue: "minha_fila",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);





            _channel.BasicPublish(exchange: "",
                        routingKey: "minha_fila",
                        basicProperties: null,
                        body: body);
           

        }

        public bool SendMessage(Tarefa tarefa)
        {
            try
            {
                var message = JsonConvert.SerializeObject(tarefa);
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void StartListening(Action<string> messageHandler)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                messageHandler(message);
            };

            
                    

                _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}