using System;

namespace Order.Management.Reports
{
    public class InvoiceReport : Report
    {
        public int tableWidth = 73;

        public InvoiceReport(Order order) : base(order)
        {
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(Order.ToString());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + Order.OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            return Order.OrderedBlocks[0].NumberOfRedShape + Order.OrderedBlocks[1].NumberOfRedShape +
                   Order.OrderedBlocks[2].NumberOfRedShape;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * Order.OrderedBlocks[0].AdditionalCharge;
        }
        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", Order.OrderedBlocks[0].NumberOfRedShape.ToString(), Order.OrderedBlocks[0].NumberOfBlueShape.ToString(), Order.OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", Order.OrderedBlocks[1].NumberOfRedShape.ToString(), Order.OrderedBlocks[1].NumberOfBlueShape.ToString(), Order.OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", Order.OrderedBlocks[2].NumberOfRedShape.ToString(), Order.OrderedBlocks[2].NumberOfBlueShape.ToString(), Order.OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
        public void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + Order.OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + Order.OrderedBlocks[0].Price + " ppi = $" + Order.OrderedBlocks[0].Total());
        }
        public void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + Order.OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + Order.OrderedBlocks[1].Price + " ppi = $" + Order.OrderedBlocks[1].Total());
        }
        public void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + Order.OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + Order.OrderedBlocks[2].Price + " ppi = $" + Order.OrderedBlocks[2].Total());
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
