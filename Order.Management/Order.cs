// Remove unused references
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Order
    {
        // Similar comment as Shape.cs
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        // Not sure if this is even assigned?
        public int OrderNumber { get; set; }
        public List<Shape> OrderedBlocks { get; set; }

        public abstract void GenerateReport();
        // Add a protected abstract method for GenerateTable with the implementation from PaintingReport/InvoiceReport

        // Add new keyword to distinguish this method from the object.ToString() method
        public string ToString()
        {
            // String interpolation and lamba
            return "\nName: " + CustomerName + " Address: " + Address + " Due Date: " + DueDate + " Order #: " + OrderNumber;
        }
    }
}
