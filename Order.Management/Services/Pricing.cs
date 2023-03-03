using System;
using Order.Management.Models;

namespace Order.Management.Services
{
    public interface IPricing
    {
        public decimal GetPrice(ToyShape shape);
        public decimal GetPrice(ToyColor color);
    }

    public class DefaultPricing : IPricing
    {
        public decimal GetPrice(ToyShape shape)
        {
            return shape switch
            {
                ToyShape.Square => 1,
                ToyShape.Triangle => 2,
                ToyShape.Circle => 3,
                _ => throw new Exception("Unknown shape")
            };
        }

        public decimal GetPrice(ToyColor color)
        {
            return color == ToyColor.Red ? 1 : 0;
        }
    }
}
