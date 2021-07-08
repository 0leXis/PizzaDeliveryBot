using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    public class SimplePathFinder : IPathFinder
    {
        protected IField _field;

        public IField Field
        {
            get => _field;
            set
            {
                if (value == null)
                    throw new ArgumentException("Field can't be null");
                _field = value;
            }
        }

        public SimplePathFinder(IField _field)
        {
            Field = _field;
        }
        public virtual string CalculatePath()
        {
            StringBuilder path = new StringBuilder();
            Point startPoint = new Point(0, 0);
            foreach (var deliveryPoint in _field.PointsToVisit)
            {
                WriteNextPathPart(startPoint, deliveryPoint, path);
                startPoint = deliveryPoint;
            }
            return path.ToString();
        }

        protected void WriteNextPathPart(Point firstPoint, Point lastPoint, StringBuilder path)
        {
            // Right/Left
            if (lastPoint.X - firstPoint.X > 0)
                path.Append('E', lastPoint.X - firstPoint.X);
            else
                path.Append('W', firstPoint.X - lastPoint.X);
            // Up/Down
            if (lastPoint.Y - firstPoint.Y > 0)
                path.Append('N', lastPoint.Y - firstPoint.Y);
            else
                path.Append('S', firstPoint.Y - lastPoint.Y);
            //Drop
            path.Append('D');
        }
    }
}
