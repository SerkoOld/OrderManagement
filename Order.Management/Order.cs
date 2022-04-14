using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public int OrderNumber { get; set; }
        public int NumberOfRedShape { get; set; }

        public Dictionary<string, int> NumberOfColorShape{ get; set; }

        public List<Order> OrderedBlocks { get; set; }

        public int TotalQuantityOfShape()
        {
            return NumberOfColorShape["Red"] + NumberOfColorShape["Blue"] + NumberOfColorShape["Yellow"];
        }

        //override ToString()
        public override string ToString()
        {
            return "\nName: " + CustomerName + " Address: " + Address + " Due Date: " + DueDate + " Order #: " + OrderNumber;
        }
    }
}
