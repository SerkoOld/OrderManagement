using System.Linq;

namespace Order.Management.Reports
{
    internal class CuttingListReport : BaseReport
    {
        public CuttingListReport(Order order) : base(order)
        {
            TableWidth = 20;
            ReportName = "cutting list report";
        }

        public override void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();

            foreach (var groupedOrder in Order.OrderedBlocks.GroupBy(o => o.Name))
            {
                PrintRow(groupedOrder.Key, groupedOrder.Sum(o => o.NumberOfShapes).ToString());
            }

            PrintLine();
        }
    }
}
