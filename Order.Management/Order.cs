using System;
using System.Collections.Generic;
using Order.Management.Reports;

namespace Order.Management
{
    abstract class Order
    {
        // Convert Properties to a class
        public ICustomer customer { get; set; }

        public readonly IEnumerable<Type> Shapes = Helpers.GetAllSubclassOf(typeof(Shape));
        public abstract void GenerateReport();
        // need override keyword
        public override string ToString()
        {
            return customer.ToString();
        }
    }
}
