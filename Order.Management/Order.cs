using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Order
    {
        // Convert Properties to a class
        public Customer customer { get; set; }
        public abstract void GenerateReport();
        // need override keyword
        public override string ToString()
        {
            return "\nName: " + customer.CustomerName + " Address: " + customer.Address + " Due Date: " + customer.DueDate + " Order #: " + customer.OrderNumber;
        }
    }
}
