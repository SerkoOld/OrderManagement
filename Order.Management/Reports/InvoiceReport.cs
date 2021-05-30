using System;
using System.Globalization;
using System.Linq;

namespace Order.Management.Reports
{
    internal class InvoiceReport : PaintingReport
    {
        public InvoiceReport(Order order) : base(order)
        {
            TableWidth = 73;
            ReportName = "invoice report";
        }

        public override void GenerateReport()
        {
            base.GenerateReport();

            // paint all shapes
            PaintOrderDetails(Order);

            // paint all colors with surcharges
            PaintSurcharge();
        }

        private void PaintSurcharge()
        {
            var ordersWithSurcharge = Order.OrderedBlocks.Where(order => order.Color.AdditionalCharge > 0).ToArray();
            if (ordersWithSurcharge.Any())
            {
                foreach (var groupedOrder in ordersWithSurcharge.GroupBy(o => o.Color.Name))
                {
                    var text = groupedOrder.Key + " Color Surcharge";
                    Console.WriteLine(
                        $"{text.PadRight(30)}{groupedOrder.Sum(o => o.Quantity).ToString()} @ "
                        + $"${groupedOrder.First().Color.AdditionalCharge.ToString()} ppi = "
                        + $"${groupedOrder.Sum(o => o.AdditionalChargeTotal()).ToString(CultureInfo.InvariantCulture)}");
                }
            }

            Console.WriteLine();
        }

        private void PaintOrderDetails(Order order)
        {
            var groupedOrders = order.OrderedBlocks.GroupBy(o => o.ShapeName);

            foreach (var groupedOrder in groupedOrders)
            {
                PaintShapeDetails(groupedOrder.Key, groupedOrder.Sum(o => o.Quantity),
                    groupedOrder.FirstOrDefault().Price,
                    groupedOrder.Sum(o => o.Total()));
            }
        }

        private void PaintShapeDetails(string shapeName, int quantity, double price, double total)
        {
            Console.WriteLine(
                $"{shapeName.PadRight(30)}{quantity.ToString()} @ ${price.ToString(CultureInfo.InvariantCulture)} ppi = ${total.ToString(CultureInfo.InvariantCulture)}");
        }
    }
}