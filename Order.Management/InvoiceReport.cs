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
            OrderShapeDetails();
            RedPaintSurcharge();
            GetTotalAmount();
        }

        private void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + _order.CustomerInfo.OrderedShape[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        private int TotalAmountOfRedShapes()
        {
            var total = 0;
            foreach (var orderedShape in _order.CustomerInfo.OrderedShape)
            {
                total += orderedShape.ColorNumbers[Color.Red];
            }
            return total;
        }

        private int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * _order.CustomerInfo.OrderedShape[0].AdditionalCharge;
        }

        private void OrderShapeDetails()
        {
            Console.WriteLine("");
            foreach (var block in _order.CustomerInfo.OrderedShape)
            {
                Console.WriteLine(block.Name + " 		  " + block.TotalQuantityOfShape() + " @ $" + block.Price + " ppi = $" + block.Total());
            }
        }

        private void GetTotalAmount()
        {
            Console.WriteLine($"Total: ${TotalPriceRedPaintSurcharge() + GetTotalBasedOnShape()}");
        }

        private decimal GetTotalBasedOnShape()
        {
            var total = 0;
            foreach (var block in _order.CustomerInfo.OrderedShape)
            {
                total += block.Total();
            }
            return total;
        }
    }
}
