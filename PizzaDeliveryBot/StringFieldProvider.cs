using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace PizzaDeliveryBot
{
    public class StringFieldProvider : IFieldProvider
    {
        public string InputString { get; set; }

        public StringFieldProvider(string inputString)
        {
            InputString = inputString;
        }

        public IField GetField()
        {
            Regex inputPattern = new Regex(@"([0-9]+)x([0-9]+)(( \([0-9]+, [0-9]+\))*)");
            Match match = inputPattern.Match(InputString);
            if (!match.Success || match.Length != InputString.Length)
                throw new ArgumentException("Wrong string format");

            if(!int.TryParse(match.Groups[1].Value, out int width))
                throw new ArgumentException("Width is too big or not a number");
            if (!int.TryParse(match.Groups[2].Value, out int height))
                throw new ArgumentException("Height is too big or not a number");

            Regex pointPattern = new Regex(@"\(([0-9]+), ([0-9]+)\)");
            // List of x and y components of all points
            var pointsInput = pointPattern.Split(match.Groups[3].Value).Where(x => x != " " && x != "").ToList();
            List<Point> points = new List<Point>();
            for(int i = 0; i < pointsInput.Count; i += 2)
            {
                if (!int.TryParse(pointsInput[i], out int pointX))
                    throw new ArgumentException("X of point " + (i / 2) + " is too big or not a number");
                if (!int.TryParse(pointsInput[i + 1], out int pointY))
                    throw new ArgumentException("Y of point " + (i / 2) + " is too big or not a number");
                points.Add(new Point(pointX, pointY));
            }

            return new Field(width, height, points);
        }
    }
}
