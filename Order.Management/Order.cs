using System.Collections.Generic;
using System.Globalization;
using Order.Management.Shapes;

namespace Order.Management
{
    public class Order
    {
        public CustomerInfo CustomerInfo { get; }

        private string OrderNumber { get; }

        public IEnumerable<IShape> OrderedBlocks { get; set; }

        public Order(string orderNumber, CustomerInfo customerInfo, IEnumerable<IShape> blocks)
        {
            OrderNumber = orderNumber;
            CustomerInfo = customerInfo;
            OrderedBlocks = blocks;
        }

        public override string ToString()
        {
            return
                $"\nName: {CustomerInfo.Name} Address: {CustomerInfo.Address} Due Date: {CustomerInfo.DueDate.ToString(CultureInfo.InvariantCulture)} Order #: {OrderNumber}";
        }
    }
}