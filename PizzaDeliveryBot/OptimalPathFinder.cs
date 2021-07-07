using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    class OptimalPathFinder : SimplePathFinder
    {
        public OptimalPathFinder(IField _field) : base(_field) { }

        public override string CalculatePath()
        {
            StringBuilder path = new StringBuilder();
            (int x, int y) startPoint = (0, 0);
            var pointsToVisit = new List<(int x, int y)>(_field.PointsToVisit);

            while (pointsToVisit.Count > 0)
            {
                int minDistance = int.MaxValue;
                (int x, int y) deliveryPoint = pointsToVisit[0];
                foreach (var point in pointsToVisit)
                {
                    int currentDistance = Math.Abs(startPoint.x - point.x) + Math.Abs(startPoint.y - point.y);
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
