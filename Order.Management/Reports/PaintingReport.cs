using Order.Management.Colors;
using System.Linq;

namespace Order.Management.Reports
{
    internal class PaintingReport : BaseReport
    {
        public PaintingReport(Order order) : base(order)
        {
            TableWidth = 73;
            ReportName = "painting report";
        }

        public override void GenerateTable()
        {
            PrintLine();

            PrintRow("        ", $"   {nameof(Red)}   ", $"  {nameof(Blue)}  ", $" {nameof(Yellow)} ");
            PrintLine();

            foreach (var groupedOrder in this.Order.OrderedBlocks.GroupBy(o => o.Name))
            {
                var redQuantity = groupedOrder.Where(shape => shape.Color is Red).Sum(o => o.NumberOfShapes);
                var yellowQuantity = groupedOrder.Where(shape => shape.Color is Yellow).Sum(o => o.NumberOfShapes);
                var blueQuantity = groupedOrder.Where(shape => shape.Color is Blue).Sum(o => o.NumberOfShapes);

                PrintRow(groupedOrder.Key, redQuantity.ToString(),
                    blueQuantity.ToString(), yellowQuantity.ToString());
            }

            PrintLine();
        }
    }
}
