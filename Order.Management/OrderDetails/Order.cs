using Order.Management.Shapes;
using System;
using System.Collections.Generic;

namespace Order.Management.OrderDetails
{
    public class Order : IOrder
    {
        private List<Shape> OrderedBlocks { get; }

        public Circle Circle => (Circle)OrderedBlocks.Find(blocks => blocks.Name == ShapeName.Circle);
        public Square Square => (Square)OrderedBlocks.Find(blocks => blocks.Name == ShapeName.Square);
        public Triangle Triangle => (Triangle)OrderedBlocks.Find(blocks => blocks.Name == ShapeName.Triangle);

        public CustomerInfo CustomerInfo { get; }
        public DateTime DueDate { get; }
        public int OrderNumber { get; }

        public Order(CustomerInfo customerInfo, DateTime dueDate, List<Shape> orderedBlocks)
        {
            CustomerInfo = customerInfo ?? throw new ArgumentNullException(nameof(customerInfo));
            DueDate = dueDate;
            OrderedBlocks = orderedBlocks ?? throw new ArgumentNullException(nameof(orderedBlocks));
            //Nothing is said about generating OrderNumber, so I left it as it was defaulted to zero
        }

        public string PrintOrderDetails()
        {
            return "\nName: " + CustomerInfo.Name + " Address: " + CustomerInfo.Address + " Due Date: " + DueDate.ToString("dd MMM yyyy") + " Order #: " + OrderNumber;
        }

        public decimal Total()
        {
            var total = Circle.Total() + Circle.RedColorChargeTotal() +
                        Square.Total() + Square.RedColorChargeTotal() +
                        Triangle.Total() + Triangle.RedColorChargeTotal();
            return total;
        }
    }
}
