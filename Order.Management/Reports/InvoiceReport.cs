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
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + Order.OrderedShapes[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            return Order.OrderedShapes[0].NumberOfRedShape + Order.OrderedShapes[1].NumberOfRedShape +
                   Order.OrderedShapes[2].NumberOfRedShape;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * Order.OrderedShapes[0].AdditionalCharge;
        }
        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", Order.OrderedShapes[0].NumberOfRedShape.ToString(), Order.OrderedShapes[0].NumberOfBlueShape.ToString(), Order.OrderedShapes[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", Order.OrderedShapes[1].NumberOfRedShape.ToString(), Order.OrderedShapes[1].NumberOfBlueShape.ToString(), Order.OrderedShapes[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", Order.OrderedShapes[2].NumberOfRedShape.ToString(), Order.OrderedShapes[2].NumberOfBlueShape.ToString(), Order.OrderedShapes[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
        public void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + Order.OrderedShapes[0].TotalQuantityOfShape() + " @ $" + Order.OrderedShapes[0].Price + " ppi = $" + Order.OrderedShapes[0].Total());
        }
        public void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + Order.OrderedShapes[1].TotalQuantityOfShape() + " @ $" + Order.OrderedShapes[1].Price + " ppi = $" + Order.OrderedShapes[1].Total());
        }
        public void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + Order.OrderedShapes[2].TotalQuantityOfShape() + " @ $" + Order.OrderedShapes[2].Price + " ppi = $" + Order.OrderedShapes[2].Total());
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
