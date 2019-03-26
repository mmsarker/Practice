using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQPractice
{
    public class OneWayMessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;

        public OneWayMessageReceiver(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {

        }
    }

    public class Consumer
    {
        public void Consume()
        {
            string queueName = "Sankarpai";
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";
            factory.Port = 5672;

            var connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.BasicConsume(queueName, true, new OneWayMessageReceiver(channel));
            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (ch, ea) =>
            //{
            //    var body = ea.Body;
            //    channel.BasicAck(ea.DeliveryTag, false);
            //};
            //String consumerTag = channel.BasicConsume(queueName, false, consumer);
        }
    }
}