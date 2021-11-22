using System;

namespace Order.Management
{
    class InvoiceReport : ReportBase
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
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + _order.CustomerInfo.OrderedShape[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            var total = 0;
            foreach (var orderedShape in _order.CustomerInfo.OrderedShape)
            {
                total += orderedShape.ColorNumbers[Color.Red];
            }
            return total;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * _order.CustomerInfo.OrderedShape[0].AdditionalCharge;
        }
        private void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + _order.CustomerInfo.OrderedShape[0].TotalQuantityOfShape() + " @ $" + _order.CustomerInfo.OrderedShape[0].Price + " ppi = $" + _order.CustomerInfo.OrderedShape[0].Total());
        }
        private void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + _order.CustomerInfo.OrderedShape[1].TotalQuantityOfShape() + " @ $" + _order.CustomerInfo.OrderedShape[1].Price + " ppi = $" + _order.CustomerInfo.OrderedShape[1].Total());
        }
        private void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + _order.CustomerInfo.OrderedShape[2].TotalQuantityOfShape() + " @ $" + _order.CustomerInfo.OrderedShape[2].Price + " ppi = $" + _order.CustomerInfo.OrderedShape[2].Total());
        }

        private void GetTotalAmount()
        {
            Console.WriteLine($"Total: ${TotalAmountOfRedShapes() + _order.CustomerInfo.OrderedShape[0].Total() + _order.CustomerInfo.OrderedShape[1].Total() + _order.CustomerInfo.OrderedShape[2].Total()}");
        }
    }
}
