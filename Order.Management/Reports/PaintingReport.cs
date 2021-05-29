using System.Linq;
using Order.Management.Colors;

namespace Order.Management.Reports
{
    class PaintingReport : BaseReport
    {
        public PaintingReport(CustomerInfo customerInfo, Order order) : base(customerInfo, order)
        {
            TableWidth = 73;
        }

        protected override void GenerateTable()
        {
            PrintLine();

            PrintRow("        ", $"   {nameof(Red)}   ", $"  {nameof(Blue)}  ", $" {nameof(Yellow)} ");
            PrintLine();

            foreach (var groupedOrder in this.Order.OrderedBlocks.GroupBy(o => o.ShapeName))
            {
                var redQuantity = groupedOrder.Where(shape => shape.Color is Red).Sum(o => o.Quantity);
                var yellowQuantity = groupedOrder.Where(shape => shape.Color is Yellow).Sum(o => o.Quantity);
                var blueQuantity = groupedOrder.Where(shape => shape.Color is Blue).Sum(o => o.Quantity);

                PrintRow(groupedOrder.Key, redQuantity.ToString(),
                    blueQuantity.ToString(), yellowQuantity.ToString());
            }

            PrintLine();
        }
    }
}