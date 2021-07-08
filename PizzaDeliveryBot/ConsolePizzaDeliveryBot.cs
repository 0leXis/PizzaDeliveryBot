using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    public class ConsolePizzaDeliveryBot : IPizzaDeliveryBot
    {
        private IPathFinder _pathFinder;

        public IPathFinder PathFinder
        {
            get => _pathFinder;
            set
            {
                if (value == null)
                    throw new ArgumentException("PathFinder can't be null");
                _pathFinder = value;
            }
        }

        public ConsolePizzaDeliveryBot(IPathFinder pathFinder)
        {
            PathFinder = pathFinder;
        }
        public void DeliverPizza()
        {
            string path = PathFinder.CalculatePath();
            if (path == "")
                Console.WriteLine("No delivery points");
            else
                Console.WriteLine(PathFinder.CalculatePath());
        }
    }
}
