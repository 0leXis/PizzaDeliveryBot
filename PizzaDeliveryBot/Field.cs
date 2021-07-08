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
            if (width <= 0)
                throw new ArgumentException("width can't be negative or zero");
            if (height <= 0)
                throw new ArgumentException("height can't be negative or zero");
            if (pointsToVisit == null)
                throw new ArgumentNullException("pointsToVisit can't be null");
            foreach(var point in pointsToVisit)
                if(point.X < 0 || point.X >= width ||
                   point.Y < 0 || point.Y >= height)
                    throw new ArgumentException("pointsToVisit contains an out of bounds point");

            FieldWidth = width;
            FieldHeight = height;
            PointsToVisit = new List<Point>(pointsToVisit);
        }
    }
}
