using Order.Management.Shapes;
using System.Collections.Generic;

namespace Order.Management
{
    public class Order
    {
        public Customer Customer { get; }
        public string OrderNumber { get; }
        public List<Shape> OrderedBlocks { get; set; }

        public Order(string orderNumber, Customer customer, List<Shape> orderedBlocks)
        {
            OrderNumber = orderNumber; 
            Customer = customer;
            OrderedBlocks = orderedBlocks;
        }

        public override string ToString()
        {
            return $"\nName: {Customer.Name} Address: {Customer.Address} Due Date: {Customer.DueDate} Order #: {OrderNumber}";
        }
    }
}
