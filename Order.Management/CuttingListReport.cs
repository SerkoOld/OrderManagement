using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CuttingListReport : Report
    {
        public int tableWidth = 20;
        Order order = new Order();
        public CuttingListReport(string customerName, string address, string dueDate, List<Order> shapes)
        {
            order.CustomerName = customerName;
            order.Address = address;
            order.DueDate = dueDate;
            order.OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(order.ToString());
            generateTable();
        }
        public void generateTable()
        {
            PrintLine(tableWidth);
            PrintRow(tableWidth, "        ", "   Qty   ");
            PrintLine(tableWidth);
            PrintRow(tableWidth, "Square", order.OrderedBlocks[0].TotalQuantityOfShape().ToString());
            PrintRow(tableWidth, "Triangle", order.OrderedBlocks[1].TotalQuantityOfShape().ToString());
            PrintRow(tableWidth, "Circle", order.OrderedBlocks[2].TotalQuantityOfShape().ToString());
            PrintLine(tableWidth);
        }
    }
}
