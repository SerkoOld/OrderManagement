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
        public static Dictionary<string,Colour> ColoursDict { get; set; }
        public static void Prompt<T>(int additonalCharge) where T : class
        {
            var type = typeof(T);
            var shapeName = type.Name;
            ColoursDict = new Dictionary<string, Colour>();
            foreach (var colour in Colours)
            {
                Console.Write($"Please input the number of {colour} {shapeName} : ");
                int shapeCount = Helpers.userShapeNumbers();
                ColoursDict[colour] = new Colour
                {
                    Name = shapeName,
                    ColourNos = shapeCount,
                    AdditionalCharge = additonalCharge
                };
            }
        }

    }
}
