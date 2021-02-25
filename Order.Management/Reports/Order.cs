using System.Collections.Generic;

namespace Order.Management
{
    abstract class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public int OrderNumber { get; set; } = 1;
        public List<Shape> OrderedBlocks { get; set; }

        public Order(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = shapes;
        }

        public abstract void GenerateReport();

        public string GenerateOrderInfo()
        {
            return string.Format(
                "\nName: {0} Address: {1} Due Date: {2} Order #: {3}",
                CustomerName,
                Address,
                DueDate,
                OrderNumber.ToString().PadLeft(4, '0')
                ); ;
        }
    }
}
