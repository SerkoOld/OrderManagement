using Order.Management.Helpers;
using System;
using System.Collections.Generic;

namespace Order.Management
{
    class PaintingReport : Order
    {
        public const int tableWidth = 73;

        public PaintingReport(string customerName,
            string customerAddress,
            string dueDate,
            List<Shape> shapes) : base(
            customerName,
            customerAddress,
            dueDate,
            shapes)
        { }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(GenerateOrderInfo());
            generateTable();
        }

        public void generateTable()
        {
            TableHelper.GenerateTable(tableWidth, OrderedBlocks);
        }

    }
}
