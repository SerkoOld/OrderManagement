using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class InvoiceReport : Order
    {
        private int tableWidth = 73;
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
            Console.WriteLine(base.ToString());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            return OrderedBlocks[0].NumberOfRedShape + OrderedBlocks[1].NumberOfRedShape +
                   OrderedBlocks[2].NumberOfRedShape;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * OrderedBlocks[0].AdditionalCharge;
        }
        public void GenerateTable()
        {
            PrintLine(new string('-', tableWidth));
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine(new string('-', tableWidth));
            PrintRow("Square", OrderedBlocks[0].NumberOfRedShape.ToString(), OrderedBlocks[0].NumberOfBlueShape.ToString(), OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", OrderedBlocks[1].NumberOfRedShape.ToString(), OrderedBlocks[1].NumberOfBlueShape.ToString(), OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", OrderedBlocks[2].NumberOfRedShape.ToString(), OrderedBlocks[2].NumberOfBlueShape.ToString(), OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine(new string('-', tableWidth));
        }
        public void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + OrderedBlocks[0].Price + " ppi = $" + OrderedBlocks[0].Total());
        }
        public void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + OrderedBlocks[1].Price + " ppi = $" + OrderedBlocks[1].Total());
        }
        public void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + OrderedBlocks[2].Price + " ppi = $" + OrderedBlocks[2].Total());
        }
        //Consider moving this to the base class 

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
