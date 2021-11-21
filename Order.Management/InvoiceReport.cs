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
            var total = 0;
            foreach (var orderedShape in Order.CustomerInfo.OrderedShape)
            {
                total += orderedShape.ColorNumbers[Color.Red];
            }
            return total;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * Order.CustomerInfo.OrderedShape[0].AdditionalCharge;
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
