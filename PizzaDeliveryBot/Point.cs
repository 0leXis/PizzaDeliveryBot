﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
