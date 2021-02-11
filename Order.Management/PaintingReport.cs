using System;
using System.Collections.Generic;

namespace Order.Management
{
    class PaintingReport : Order
    {
        public PaintingReport(string customerName, string customerAddress, string dueDate, List<Shape> orderedBlocks) : base (customerName, customerAddress, dueDate, orderedBlocks)
        {
            tableWidth = 73;
            OrderNumber += 1;
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = orderedBlocks;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(ToString());
            GenerateTable();
        }

    }
}
