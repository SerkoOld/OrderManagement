using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class InvoiceReport : Order
    {
        public int tableWidth = 73;
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + base.OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            return base.OrderedBlocks[0].NumberOfRedShape + base.OrderedBlocks[1].NumberOfRedShape +
                   base.OrderedBlocks[2].NumberOfRedShape;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * base.OrderedBlocks[0].AdditionalCharge;
        }
        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", base.OrderedBlocks[0].NumberOfRedShape.ToString(), base.OrderedBlocks[0].NumberOfBlueShape.ToString(), base.OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", base.OrderedBlocks[1].NumberOfRedShape.ToString(), base.OrderedBlocks[1].NumberOfBlueShape.ToString(), base.OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", base.OrderedBlocks[2].NumberOfRedShape.ToString(), base.OrderedBlocks[2].NumberOfBlueShape.ToString(), base.OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
        public void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + base.OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[0].Price + " ppi = $" + base.OrderedBlocks[0].Total());
        }
        public void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + base.OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[1].Price + " ppi = $" + base.OrderedBlocks[1].Total());
        }
        public void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + base.OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[2].Price + " ppi = $" + base.OrderedBlocks[2].Total());
        }
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
