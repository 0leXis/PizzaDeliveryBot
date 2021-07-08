using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    public class OptimalPathFinder : SimplePathFinder
    {
        public OptimalPathFinder(IField _field) : base(_field) { }

        public override string CalculatePath()
        {
            StringBuilder path = new StringBuilder();
            Point startPoint = new Point(0, 0);
            var pointsToVisit = new List<Point>(_field.PointsToVisit);

            while (pointsToVisit.Count > 0)
            {
                int minDistance = int.MaxValue;
                Point deliveryPoint = pointsToVisit[0];
                //Finding nearest cell
                foreach (var point in pointsToVisit)
                {
                    int currentDistance = Math.Abs(startPoint.X - point.X) + Math.Abs(startPoint.Y - point.Y);
                    if (currentDistance < minDistance)
                    {
                        deliveryPoint = point;
                        minDistance = currentDistance;
                    }
                }
                pointsToVisit.Remove(deliveryPoint);
                WriteNextPathPart(startPoint, deliveryPoint, path);
                startPoint = deliveryPoint;
            }
            return path.ToString();
        }
    }
}
