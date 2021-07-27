using System;
using System.Globalization;
using System.Linq;

namespace Order.Management.Reports
{
    internal class InvoiceReport : BaseReport
    {
        public InvoiceReport(Order order) : base(order)
        {
            TableWidth = 73;
            ReportName = "invoice report";
        }

        public override void GenerateReport()
        {
            base.GenerateReport();
            PaintOrderDetails(Order);
            PaintSurcharge();
        }

        protected void PaintOrderDetails(Order order)
        {
            var groupedOrders = order.OrderedBlocks.GroupBy(o => o.Name);

            foreach (var groupedOrder in groupedOrders)
            {
                PaintShapeDetails(groupedOrder.Key, groupedOrder.Sum(o => o.NumberOfShapes),
                    groupedOrder.FirstOrDefault().Price,
                    groupedOrder.Sum(o => o.Total()));
            }
        }

        protected void PaintSurcharge()
        {
            var ordersWithSurcharge = Order.OrderedBlocks.Where(order => order.Color.Surcharge > 0).ToArray();
            if (ordersWithSurcharge.Any())
            {
                foreach (var groupedOrder in ordersWithSurcharge.GroupBy(o => o.Color.Name))
                {
                    var text = groupedOrder.Key + " Color Surcharge";
                    Console.WriteLine(
                        $"{text.PadRight(30)}{groupedOrder.Sum(o => o.NumberOfShapes)} @ "
                        + $"${groupedOrder.First().Color.Surcharge} ppi = "
                        + $"${groupedOrder.Sum(o => o.SurchargeTotal())}");
                }
            }

            Console.WriteLine();
        }

        protected void PaintShapeDetails(string shapeName, int quantity, double price, decimal total)
        {
            Console.WriteLine(
                $"{shapeName.PadRight(30)}{quantity} @ ${price} ppi = ${total}");
        }
    }
}
