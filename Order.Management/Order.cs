using System.Collections.Generic;
using Order.Management.Shapes;

namespace Order.Management
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public int OrderNumber { get; set; }
        public List<Shape> OrderedShapes { get; set; }

        public override string ToString()
        {
            return $"\nName: {CustomerName}  Address: {Address} Due Date: {DueDate} Order #: {OrderNumber}";
        }
    }
}
