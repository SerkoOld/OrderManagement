using Order.Management.Shapes;
using System;
using System.Collections.Generic;

namespace Order.Management.OrderDetails
{
    public class Order
    {
        public Order(CustomerInfo customerInfo, DateTime dueDate, List<Shape> orderedBlocks)
        {
            CustomerInfo = customerInfo;
            DueDate = dueDate;
            OrderedBlocks = orderedBlocks;
            //Nothing is said about generating OrderNumber, so I left it as it was defaulted to zero
        }

        public CustomerInfo CustomerInfo { get; }
        public DateTime DueDate { get; }
        public int OrderNumber { get; }
        public List<Shape> OrderedBlocks { get; }

        public string PrintOrderDetails()
        {
            return "\nName: " + CustomerInfo.Name + " Address: " + CustomerInfo.Address + " Due Date: " + DueDate.ToString("dd MMM yyyy") + " Order #: " + OrderNumber;
        }
    }
}
