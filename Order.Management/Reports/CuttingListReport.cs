using System;

namespace Order.Management.Reports
{
    class CuttingListReport : BaseReport
    {
        private readonly OrderDetails.Order _order;
        protected override int TableWidth => 20;

        public CuttingListReport(OrderDetails.Order order)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(_order.PrintOrderDetails());
            generateTable();
        }
        private void generateTable()
        {
            PrintLine();
            PrintRow("", "Qty");
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

            PrintRow(shape.Name.ToString(), shape.TotalQuantityOfShape().ToString());
        }
    }
}
