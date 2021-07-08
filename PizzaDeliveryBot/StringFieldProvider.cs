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
            Regex inputPattern = new Regex(@"([0-9]+)x([0-9]+)(( \([0-9]+, [0-9]+\))+)");
            Match match = inputPattern.Match(InputString);
            if (!match.Success || match.Length != InputString.Length)
                throw new ArgumentException("Wrong string format");

            int width = int.Parse(match.Groups[1].Value);
            int height = int.Parse(match.Groups[2].Value);

            Regex pointPattern = new Regex(@"\(([0-9]+), ([0-9]+)\)");
            // List of x and y components of all points
            var pointsInput = pointPattern.Split(match.Groups[3].Value).Where(x => x != " " && x != "").ToList();
            List<Point> points = new List<Point>();
            for(int i = 0; i < pointsInput.Count; i += 2)
                points.Add(new Point(int.Parse(pointsInput[i]), int.Parse(pointsInput[i + 1])));

            return new Field(width, height, points);
        }
    }
}
