using Order.Management.Helpers;
using System;
using System.Collections.Generic;

namespace Order.Management
{
    class CuttingListReport : Order
    {
        public const int tableWidth = 20;

        public CuttingListReport(
            string customerName, 
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
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(GenerateOrderInfo());
            GenerateTable();
        }
        private void GenerateTable()
        {
            TableHelper.GenerateCuttingTable(tableWidth, OrderedBlocks);
        }

    }
}
