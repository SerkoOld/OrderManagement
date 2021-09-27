using System.Collections.Generic;
using System.Linq;
using Order.Management.Enums;

namespace Order.Management.Models
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> OrderedBlocks { get; set; }

        public decimal RedPaintSurcharge => GetNumbersOfColour(ShapeColours.Red) * Constants.AdditionalCharge;

        public int GetNumbersOfColour(ShapeColours colour)
        {
            return OrderedBlocks.Where(_ => _.Shape.Colour.Equals(colour)).ToList().Sum(_ => _.Quantity);
        }

        public int GetNumbersOfShapeWithColour(Shapes shape, ShapeColours colour)
        {
            return OrderedBlocks.Where(_ => _.Shape.Name.Equals(shape) && _.Shape.Colour.Equals(colour)).ToList().Sum(_ => _.Quantity);
        }

        public int GetNumbersOfShape(Shapes shape)
        {
            return OrderedBlocks.Where(_ => _.Shape.Name.Equals(shape)).ToList().Sum(_ => _.Quantity);
        }

        public decimal GetPriceTotalByShape(Shapes shape)
        {
            return shape.GetUnitPrice() * GetNumbersOfShape(shape);
        }

        public override string ToString()
        {
            return $"\nName: {CustomerName} Address: {Address} Due Date: {DueDate} Order #: {OrderNumber}";
        }
    }
}
