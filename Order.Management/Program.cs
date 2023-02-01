using System;
using System.Collections.Generic;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            var customer = new Customer();
            var report = new ReportGenerator(customer);
        }
    }
}
