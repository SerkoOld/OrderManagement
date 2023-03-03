using System;
using System.Linq;
using Order.Management.Models;

namespace Order.Management.Services
{
    public static class CommonUtils
    {
        public static ToyShape[] GetAllShapes()
        {
            return Enum.GetValues(typeof(ToyShape)).Cast<ToyShape>().ToArray();
        }

        public static ToyColor[] GetAllColors()
        {
            return Enum.GetValues(typeof(ToyColor)).Cast<ToyColor>().ToArray();
        }

        public static int GetOrderNumber()
        {
            return new Random().Next(1000, 9999);
        }
    }
}
