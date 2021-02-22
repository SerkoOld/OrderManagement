using System;
using System.Collections.Generic;

namespace Order.Management
{
    class CuttingListReport : Order
    {
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = shapes;
            ReportTableWidth = 20;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(ReportSummaryHeader());
            GenerateReportDetail("        ", "   Qty   ");
        }

        public new void GenerateReportDetail(params string[] reportDetailColumns)
        {
            PrintLine();
            PrintRow(reportDetailColumns);
            PrintLine();
            foreach (var orderedblock in OrderedBlocks)
            {
                PrintRow(orderedblock.Name, orderedblock.TotalQuantityOfShape().ToString());
            }
            PrintLine();
        }

    }
}
