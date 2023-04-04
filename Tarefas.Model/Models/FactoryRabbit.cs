using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Model.Models
{
    public class FactoryModel
    {
        public static ConnectionFactory _factoryModel = new ConnectionFactory();
        public static ConnectionFactory CreateModel()
        {


    //        var rabbitMqConnectionFactory
    //= new ConnectionFactory
    //{
    //    HostName = rabbitMqHostName,
    //    Port = rabbitMqPort,
    //    UserName = rabbitMqUserName,
    //    Password = rabbitMqPassword,
    //    VirtualHost = rabbitMqVirtualHost,
    //    RequestedHeartbeat = 60,
    //    Ssl =
    //            {
    //                **ServerName** = rabbitMqHostName,
    //                Enabled = useSsl
    //            }
    //};



            return new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 15672,

                Ssl =
                {
                    ServerName = "rabbitmq-1",
                    //Enabled = "true"
                }
            };


        }
    }
}
