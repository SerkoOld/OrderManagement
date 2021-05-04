using System;
using System.Collections.Generic;

namespace Order.Management
{
    internal class CuttingListReport : Order
    {
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
            : base(customerName, customerAddress, dueDate, shapes)
        {
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(base.ToString());

            GenerateTable();
        }

        public void GenerateTable()
        {
            ReportHelper.GenerateCuttingListReport(OrderedBlocks);
        }
    }
}