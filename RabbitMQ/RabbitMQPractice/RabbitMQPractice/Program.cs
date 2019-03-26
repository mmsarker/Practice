using System;

namespace RabbitMQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            new Consumer().Consume();
           // new RabbitMQTest().CreateConnection();            

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
