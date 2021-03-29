using System.Collections.Generic;

namespace Order.Management
{
    abstract class Order
    {
        protected string CustomerName { get; set; }
        protected string Address { get; set; }
        protected string DueDate { get; set; }
        protected int OrderNumber { get; set; }
        protected List<Shape> OrderedBlocks { get; set; }

        public abstract void GenerateReport();
        public override string ToString() => $"\nName: {CustomerName} Address: {Address} Due Date: {DueDate} Order #: {OrderNumber:0000}";
    }
}
