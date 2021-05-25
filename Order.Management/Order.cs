﻿using Order.Management.ToyBlocks;
using System.Collections.Generic;

namespace Order.Management
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public int OrderNumber => OrderedBlocks?.Count ?? 0;
        public List<Shape> OrderedBlocks { get; set; } = new List<Shape>();

        public override string ToString()
        {
            return "\nName: " + CustomerName + " Address: " + Address + " Due Date: " + DueDate + " Order #: " + OrderNumber;
        }
    }
}
