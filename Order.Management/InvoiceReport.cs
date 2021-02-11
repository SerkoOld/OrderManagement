using System;
using System.Collections.Generic;

namespace Order.Management
{
    class InvoiceReport : Order
    {
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> orderedBlocks) : base (customerName, customerAddress, dueDate, orderedBlocks)
        {
            tableWidth = 73;
            OrderNumber += 1;
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = orderedBlocks;
        }

        public int TotalAmountOfRedShapes => OrderedBlocks[0].NumberOfRedShape + OrderedBlocks[1].NumberOfRedShape +
                   OrderedBlocks[2].NumberOfRedShape;

        public int TotalPriceRedPaintSurcharge => TotalAmountOfRedShapes* OrderedBlocks[0].AdditionalCharge;

        public void RedPaintSurcharge() => Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes + " @ $" + OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge);

        public void OrderSquareDetails() => Console.WriteLine("\nSquares 		  " + OrderedBlocks[0].TotalQuantityOfShape + " @ $" + OrderedBlocks[0].Price + " ppi = $" + OrderedBlocks[0].Total);

        public void OrderTriangleDetails() => Console.WriteLine("Triangles 		  " + OrderedBlocks[1].TotalQuantityOfShape + " @ $" + OrderedBlocks[1].Price + " ppi = $" + OrderedBlocks[1].Total);

        public void OrderCircleDetails() => Console.WriteLine("Circles 		  " + OrderedBlocks[2].TotalQuantityOfShape + " @ $" + OrderedBlocks[2].Price + " ppi = $" + OrderedBlocks[2].Total);

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

    }
}
