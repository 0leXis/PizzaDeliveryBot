using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    interface IField
    {
        int FieldWidth { get; }
        int FieldHeight { get; }

        List<(int x, int y)> PointsToVisit { get; }
    }
}
