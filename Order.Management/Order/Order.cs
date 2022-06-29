using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Management
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime DueDate { get; set; }
        public int OrderNumber { get; set; }
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
                    return CommonConst.TrianglePrice;
                case Shape.Circle:
                    return CommonConst.CirclePrice;
                case Shape.Square:
                default:
                    return CommonConst.SquarePrice;
            }
        }

        public override string ToString()
        {
            return $"\nName: {CustomerName} Address: {Address} Due Date: {DueDate.ToShortDateString()} Order #: {OrderNumber}";
        }
    }
}
