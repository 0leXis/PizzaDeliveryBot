using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    public interface IField
    {
        int FieldWidth { get; }
        int FieldHeight { get; }

        List<Point> PointsToVisit { get; }
    }
}
