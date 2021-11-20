using System;

namespace Order.Management
{
    class InvoiceReport : Report
    {
        public InvoiceReport(Order order, int tableWidth)
        :base (order,"invoice",tableWidth)
        {
        }

        public override void GenerateReport()
        {
            base.GenerateReport();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
            GetTotalAmount();
        }

        public void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + Order.CustomerInfo.OrderedShape[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            return Order.CustomerInfo.OrderedShape[0].NumberOfRedShape + Order.CustomerInfo.OrderedShape[1].NumberOfRedShape +
                   Order.CustomerInfo.OrderedShape[2].NumberOfRedShape;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * Order.CustomerInfo.OrderedShape[0].AdditionalCharge;
        }
        protected override void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", Order.CustomerInfo.OrderedShape[0].NumberOfRedShape.ToString(), Order.CustomerInfo.OrderedShape[0].NumberOfBlueShape.ToString(), Order.CustomerInfo.OrderedShape[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", Order.CustomerInfo.OrderedShape[1].NumberOfRedShape.ToString(), Order.CustomerInfo.OrderedShape[1].NumberOfBlueShape.ToString(), Order.CustomerInfo.OrderedShape[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", Order.CustomerInfo.OrderedShape[2].NumberOfRedShape.ToString(), Order.CustomerInfo.OrderedShape[2].NumberOfBlueShape.ToString(), Order.CustomerInfo.OrderedShape[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
        private void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + Order.CustomerInfo.OrderedShape[0].TotalQuantityOfShape() + " @ $" + Order.CustomerInfo.OrderedShape[0].Price + " ppi = $" + Order.CustomerInfo.OrderedShape[0].Total());
        }
        private void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + Order.CustomerInfo.OrderedShape[1].TotalQuantityOfShape() + " @ $" + Order.CustomerInfo.OrderedShape[1].Price + " ppi = $" + Order.CustomerInfo.OrderedShape[1].Total());
        }
        private void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + Order.CustomerInfo.OrderedShape[2].TotalQuantityOfShape() + " @ $" + Order.CustomerInfo.OrderedShape[2].Price + " ppi = $" + Order.CustomerInfo.OrderedShape[2].Total());
        }

        private void GetTotalAmount()
        {
            Console.WriteLine($"Total: ${TotalAmountOfRedShapes() + Order.CustomerInfo.OrderedShape[0].Total() + Order.CustomerInfo.OrderedShape[1].Total() + Order.CustomerInfo.OrderedShape[2].Total()}");
        }
    }
}
