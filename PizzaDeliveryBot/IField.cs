using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PizzaDeliveryBot
{
    public interface IField
    {
        int FieldWidth { get; }
        int FieldHeight { get; }

        ReadOnlyCollection<Point> PointsToVisit { get; }
    }
}
