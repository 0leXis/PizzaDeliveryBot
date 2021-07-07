using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    class ConsolePizzaDeliveryBot: IPizzaDeliveryBot
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
            Console.WriteLine(PathFinder.CalculatePath());
        }
    }
}
