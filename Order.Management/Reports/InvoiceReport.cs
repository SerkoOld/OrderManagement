using System;
using System.Collections.Generic;
using System.Text;
using Order.Management.Shapes;

namespace Order.Management.Reports
{
    internal class InvoiceReport : Order
    {
        private const int TableWidth = 73;
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(ToString());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        private void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        private int TotalAmountOfRedShapes()
        {
            return OrderedBlocks[0].NumberOfRedShape + OrderedBlocks[1].NumberOfRedShape +
                   OrderedBlocks[2].NumberOfRedShape;
        }

        private int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * OrderedBlocks[0].AdditionalCharge;
        }
        private void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", OrderedBlocks[0].NumberOfRedShape.ToString(), OrderedBlocks[0].NumberOfBlueShape.ToString(), OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", OrderedBlocks[1].NumberOfRedShape.ToString(), OrderedBlocks[1].NumberOfBlueShape.ToString(), OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", OrderedBlocks[2].NumberOfRedShape.ToString(), OrderedBlocks[2].NumberOfBlueShape.ToString(), OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
        private void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + OrderedBlocks[0].Price + " ppi = $" + OrderedBlocks[0].Total());
        }
        private void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + OrderedBlocks[1].Price + " ppi = $" + OrderedBlocks[1].Total());
        }
        private void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + OrderedBlocks[2].Price + " ppi = $" + OrderedBlocks[2].Total());
        }
        private void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        private void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            StringBuilder row = new StringBuilder("|");

            foreach (string column in columns)
            {
                row.Append($"{AlignCentre(column, width)}|");
            }

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text[..(width - 3)] + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', width)
                : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}
