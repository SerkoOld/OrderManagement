using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class PaintingReport : Report
    {
        public int tableWidth = 73;
        Order order = new Order();
        public PaintingReport(string customerName, string address, string dueDate, List<Order> shapes)
        {
            order.CustomerName = customerName;
            order.Address = address;
            order.DueDate = dueDate;
            order.OrderedBlocks = shapes;
        }
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(order.ToString());
            generateTable();
        }

        public void generateTable()
        {
            PrintLine(tableWidth);
            PrintRow(tableWidth, "        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine(tableWidth);
            PrintRow(tableWidth, "Square", order.OrderedBlocks[0].NumberOfColorShape["Red"].ToString(), order.OrderedBlocks[0].NumberOfColorShape["Blue"].ToString(), order.OrderedBlocks[0].NumberOfColorShape["Yellow"].ToString());
            PrintRow(tableWidth, "Triangle", order.OrderedBlocks[1].NumberOfColorShape["Red"].ToString(), order.OrderedBlocks[1].NumberOfColorShape["Blue"].ToString(), order.OrderedBlocks[1].NumberOfColorShape["Yellow"].ToString());
            PrintRow(tableWidth, "Circle", order.OrderedBlocks[2].NumberOfColorShape["Red"].ToString(), order.OrderedBlocks[2].NumberOfColorShape["Blue"].ToString(), order.OrderedBlocks[2].NumberOfColorShape["Yellow"].ToString());
            PrintLine(tableWidth);
        }
    }
}
