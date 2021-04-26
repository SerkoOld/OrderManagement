using Order.Management.OrderDetails;
using System;

namespace Order.Management.Reports
{
    class CuttingListReport : IReport
    {
        private const int TableWidth = 20;
        private readonly IOrder _order;
        private readonly ReportHelper _printReportHelper;

        public CuttingListReport(IOrder order)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));
            _printReportHelper = new ReportHelper(TableWidth);
        }

        public void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(_order.PrintOrderDetails());
            GenerateTable();
        }
        private void GenerateTable()
        {
            _printReportHelper.PrintLine();
            _printReportHelper.PrintRow("", "Qty");
            _printReportHelper.PrintLine();
            PrintShapeInformationRow(_order.Square);
            PrintShapeInformationRow(_order.Triangle);
            PrintShapeInformationRow(_order.Circle);
            _printReportHelper.PrintLine();
        }

        private void PrintShapeInformationRow(Shapes.Shape shape)
        {
            if (shape is null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            _printReportHelper.PrintRow(shape.Name.ToString(), shape.TotalQuantityOfShape().ToString());
        }
    }
}
