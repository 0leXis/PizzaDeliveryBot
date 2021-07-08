using System;

namespace PizzaDeliveryBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write string in the following format: {width}x{height} ({point1x}, {point1y}) ({point2x}, {point2y}) ... ({pointNx}, {pointNy})");
            IField field = new StringFieldProvider(Console.ReadLine()).GetField();
            IPizzaDeliveryBot bot = new ConsolePizzaDeliveryBot(new OptimalPathFinder(field));
            bot.DeliverPizza();
        }
    }
}
