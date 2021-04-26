using System;

namespace Order.Management.Reports
{
    class PaintingReport : IReport
    {
        private const int TableWidth = 73; 
        private readonly OrderDetails.Order _order;
        private readonly ReportHelper _printReportHelper;

        public PaintingReport(OrderDetails.Order order)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));
            _printReportHelper = new ReportHelper(TableWidth);
        }

        public void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(_order.PrintOrderDetails());
            GenerateTable();
        }

        private void GenerateTable()
        {
            _printReportHelper.PrintLine();
            _printReportHelper.PrintRow("", "Red", "Blue", "Yellow");
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

            _printReportHelper.PrintRow(shape.Name.ToString(), shape.NumberOfRedShape.ToString(), shape.NumberOfBlueShape.ToString(), shape.NumberOfYellowShape.ToString());
        }
    }
}
