using System;
using System.Collections.Generic;

namespace Order.Management.Model
{
    abstract class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime DueDate { get; set; }
        public int OrderNumber { get; set; }
        public IList<Shape> OrderedBlocks { get; set; }
        public abstract void GenerateReport();
        public override string ToString()
        {
            return $"\nName: {CustomerName} Address: {Address} Due Date: {DueDate} Order #: {OrderNumber}";
        }
    }
}
