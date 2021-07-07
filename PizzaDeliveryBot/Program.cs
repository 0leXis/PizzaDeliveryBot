using System;

namespace PizzaDeliveryBot
{
    class Program
    {
        static void Main(string[] args)
        {
            IField field = new StringFieldProvider(Console.ReadLine()).GetField();
            IPizzaDeliveryBot bot = new ConsolePizzaDeliveryBot(new SimplePathFinder(field));
            bot.DeliverPizza();
        }
    }
}
