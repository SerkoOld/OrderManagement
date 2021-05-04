using System;
using System.Collections.Generic;

namespace Order.Management
{
    internal class PaintingReport : Order
    {
        public PaintingReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
            : base(customerName, customerAddress, dueDate, shapes)
        {
        }
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
        }

        public void GenerateTable()
        {
            ReportHelper.GenerateReport(OrderedBlocks);
        }
    }
}