using System;

namespace PizzaDeliveryBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write string in the following format: {width}x{height} ({point1x}, {point1y}) ({point2x}, {point2y}) ... ({pointNx}, {pointNy})");
            IField field;
            try
            {
                field = new StringFieldProvider(Console.ReadLine()).GetField();
                IPizzaDeliveryBot bot = new ConsolePizzaDeliveryBot(new OptimalPathFinder(field));
                bot.DeliverPizza();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: string has incorrect format. Debug info: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
