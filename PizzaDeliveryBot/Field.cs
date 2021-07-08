using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    public class Field : IField
    {
        public int FieldWidth { get; }
        public int FieldHeight { get; }

        public List<Point> PointsToVisit { get; }

        public Field(int width, int height, List<Point> pointsToVisit)
        {
            if (width < 0)
                throw new ArgumentException("width can't be negative");
            if (height < 0)
                throw new ArgumentException("height can't be negative");
            if (pointsToVisit == null)
                throw new ArgumentNullException("pointsToVisit can't be null");

            FieldWidth = width;
            FieldHeight = height;
            PointsToVisit = new List<Point>(pointsToVisit);
        }
    }
}
