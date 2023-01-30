using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Order.Management
{
    public static class ColourConfig
    {
        public static readonly List<string> Colours = new List<string> { "Red", "Yellow", "Blue"};
        public static Dictionary<string,int> ColourCounts { get; set; }
        public static void Prompt<T>() where T : class
        {
            var type = typeof(T);
            var shapeName = type.Name;
            ColourCounts = new Dictionary<string, int>();
            foreach (var colour in Colours)
            {
                Console.Write($"Please input the number of {colour} {shapeName} : ");
                int shapeCount = Helpers.userShapeNumbers();
                ColourCounts[colour] = shapeCount;
            }
        }

    }
}
