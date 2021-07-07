using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    class SimplePathFinder : IPathFinder
    {
        private IField _field;

        public IField Field
        {
            get => _field;
            set
            {
                if (value == null)
                    throw new ArgumentException("PathFinder can't be null");
                _field = value;
            }
        }

        public SimplePathFinder(IField _field)
        {
            Field = _field;
        }
        public string CalculatePath()
        {
            StringBuilder path = new StringBuilder();
            (int x, int y) startPoint = (0, 0);
            foreach (var deliveryPoint in _field.PointsToVisit)
            {
                WriteNextPathPart(startPoint, deliveryPoint, path);
                startPoint = deliveryPoint;
            }
            return path.ToString();
        }

        private void WriteNextPathPart((int x, int y) firstPoint, (int x, int y) lastPoint, StringBuilder path)
        {
            if (lastPoint.x - firstPoint.x > 0)
                path.Append('E', lastPoint.x - firstPoint.x);
            else
                path.Append('W', firstPoint.x - lastPoint.x);

            if (lastPoint.y - firstPoint.y > 0)
                path.Append('N', lastPoint.y - firstPoint.y);
            else
                path.Append('S', firstPoint.y - lastPoint.y);

            path.Append('D');
        }
    }
}
