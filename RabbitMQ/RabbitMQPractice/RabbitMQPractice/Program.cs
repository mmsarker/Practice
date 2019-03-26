using RabbitMQ.Client;
using System;

namespace RabbitMQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            new RabbitMQTest().CreateConnection();
            new Consumer().Consume();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
