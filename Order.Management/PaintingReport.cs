using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class PaintingReport : ReportBase
    {
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(Order.ToString());
            GenerateTable();
        }


        public PaintingReport(Models.Order order) : base(order)
        {
        }
    }
}
