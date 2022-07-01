using Order.Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Management.Domain
{
    public class OrderInfo
    {
        public int OrderNumber { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public List<ToyInfo> ToyInfos { get; set; }

        public int GetCountByColor(Color color)
        {
            return ToyInfos.Where(item => item.Color.Equals(color)).ToList().Sum(item => item.Quantity);
        }

        public int GetCountByShape(Enum shape)
        {
            return ToyInfos.Where(item => item.Shape.Equals(shape)).ToList().Sum(item => item.Quantity);
        }
        public int GetCountByShapeAndColor(Enum shape, Color color)
        {
            return ToyInfos.Where(item => item.Shape.Equals(shape) && item.Color.Equals(color)).ToList().Sum(item => item.Quantity);
        }

        public decimal GetShapePrice(Enum shape)
        {
            switch (shape)
            {
                case Shape.Triangle:
                    return ToyPrice.TrianglePrice;
                case Shape.Circle:
                    return ToyPrice.CirclePrice;
                case Shape.Square:
                default:
                    return ToyPrice.SquarePrice;
            }
        }

        public string ToMessage()
        {
            return $"\nName: {CustomerInfo.CustomerName} Address: {CustomerInfo.Address} Due Date: {CustomerInfo.DueDate.ToShortDateString()} Order #: {OrderNumber}";
        }
    }
}
