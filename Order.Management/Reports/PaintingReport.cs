using System;

namespace Order.Management.Reports
{
    class PaintingReport : BaseReport
    {
        private readonly OrderDetails.Order _order;
        protected override int TableWidth => 73; 

        public PaintingReport(OrderDetails.Order order)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(_order.PrintOrderDetails());
            GenerateTable();
        }

        private void GenerateTable()
        {
            PrintLine();
            PrintRow("", "Red", "Blue", "Yellow");
            PrintLine();
            PrintShapeInformationRow(_order.Square);
            PrintShapeInformationRow(_order.Triangle);
            PrintShapeInformationRow(_order.Circle);
            PrintLine();
        }

        private void PrintShapeInformationRow(Shapes.Shape shape)
        {
            if (shape is null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            PrintRow(shape.Name.ToString(), shape.NumberOfRedShape.ToString(), shape.NumberOfBlueShape.ToString(), shape.NumberOfYellowShape.ToString());
        }
    }
}
