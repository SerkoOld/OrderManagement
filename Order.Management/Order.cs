using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Order
    {
        // INSP RS Restrict access to properties. Currently they are public and can be changed anywhere in the namespace.
        public string CustomerName { get; set; }
        public string Address { get; set; }
        // INSP RS Store DueDate as a DateTime and make sure input is validated.
        public string DueDate { get; set; }
        public int OrderNumber { get; set; }
        public List<Shape> OrderedBlocks { get; set; }

        public abstract void GenerateReport();

        // INSP RS Override this method and apply string interpolation for elegance.
        public string ToString()
        {
            return "\nName: " + CustomerName + " Address: " + Address + " Due Date: " + DueDate + " Order #: " + OrderNumber;
        }
    }
}
