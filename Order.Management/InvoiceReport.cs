using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class InvoiceReport : Order
    {
        public override string ReportType => "Invoice" ;

        private string PriceAtText => "@ $";
        private string PriceTotalText => "ppi = $";
        private int TotalReds => TotalAmountOfRedShapes();

        public InvoiceReport(CustomerInfo customerInfo, List<Shape> shapes) : base(customerInfo, shapes)
        {
        }

        public override void GenerateReport()
        {
            ReportHeader(ReportType);
            GenerateTable();
            Console.WriteLine(Environment.NewLine);
            foreach (var order in OrderedBlocks)
            {
                Console.WriteLine("{0}  {1} {2}{3} {4}{5}",order.Name, order.TotalQuantity, PriceAtText, order.Price, PriceTotalText, order.TotalPrice);
            }

            RedPaintSurcharge();
        }

        private void RedPaintSurcharge()
        {
            Console.WriteLine("{0}      {1} {2}{3} {4}{5}","Red Paint Surcharge", TotalAmountOfRedShapes(), PriceAtText, TotalReds, PriceTotalText , TotalPriceRedPaintSurcharge());
        }

        private int TotalAmountOfRedShapes()
        {
            var totalReds = 0;
            foreach(var order in OrderedBlocks)
            {
                totalReds += order.NumberOfRedShape;
            }

            return totalReds;
        }

        private int TotalPriceRedPaintSurcharge()
        {
            return TotalReds * base.OrderedBlocks[0].AdditionalChargeRed;
        }
    }
}
