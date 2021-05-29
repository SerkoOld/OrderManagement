using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Order.Management.Colors;
using Order.Management.Shapes;

namespace Order.Management.Reports
{
    class InvoiceReport : PaintingReport
    {
        public InvoiceReport(CustomerInfo customerInfo, Order order) : base(customerInfo, order)
        {
            TableWidth = 73;
        }

        public override void GenerateReport()
        {
            base.GenerateReport();

            base.GenerateTable();
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
                    Console.WriteLine(
                        $"{groupedOrder.Key} Color Surcharge       {groupedOrder.Sum(o => o.Quantity).ToString()} @ "
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
                $"\n{shapeName}  {quantity.ToString()} @ ${price.ToString(CultureInfo.InvariantCulture)} ppi = ${total.ToString(CultureInfo.InvariantCulture)}");
        }
    }
}