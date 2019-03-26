using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQPractice
{
    public class RabbitMQTest
    {
        public void CreateConnection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";
            factory.Port = 5672;

            var connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            string exchangeName = "Bagmara";
            string queueName = "Machmail";
            string queueName1 = "Sankarpai";
            string routingKey = "Bagmara-Machmail";
            channel.ExchangeDeclare(exchangeName,  ExchangeType.Direct, true, false);
            channel.QueueDeclare(queueName, true, false, false, null);
            channel.QueueDeclare(queueName1, true, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);
            channel.QueueBind(queueName1, exchangeName, routingKey, null);

            IBasicProperties props = channel.CreateBasicProperties();
            props.ContentType = "text/plain";
            props.DeliveryMode = 2;

            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes("Hello, world!");
            channel.BasicPublish(exchangeName, routingKey, props, messageBodyBytes);
            channel.BasicPublish(exchangeName, routingKey, props, messageBodyBytes);
            channel.BasicPublish(exchangeName, routingKey, props, messageBodyBytes);
            channel.BasicPublish(exchangeName, routingKey, props, messageBodyBytes);

            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += Consumer_Received;

            connection.Close();
            //channel.ExchangeDeclare("Bagmara", ExchangeType.Direct);
            //channel.Close();
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
