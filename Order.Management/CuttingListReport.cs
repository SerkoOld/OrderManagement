using System;
using System.Collections.Generic;

namespace Order.Management
{
    class CuttingListReport : Order
    {
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes) : base(customerName, customerAddress, dueDate, shapes)
        {
            tableWidth = 20;
            OrderNumber += 1;
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(ToString());
            GenerateTable();
        }

        public override void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();
            PrintRow("Square", OrderedBlocks[0].TotalQuantityOfShape.ToString());
            PrintRow("Triangle", OrderedBlocks[1].TotalQuantityOfShape.ToString());
            PrintRow("Circle", OrderedBlocks[2].TotalQuantityOfShape.ToString());
            PrintLine();
        }
    }
}
