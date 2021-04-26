using System;

namespace Order.Management.Reports
{
    class PaintingReport : BaseReport
    {
        protected override int TableWidth => 73; 
        OrderDetails.Order _order;

        public PaintingReport(OrderDetails.Order order)
        {
            _order = order;
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
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", _order.OrderedBlocks[0].NumberOfRedShape.ToString(), _order.OrderedBlocks[0].NumberOfBlueShape.ToString(), _order.OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", _order.OrderedBlocks[1].NumberOfRedShape.ToString(), _order.OrderedBlocks[1].NumberOfBlueShape.ToString(), _order.OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", _order.OrderedBlocks[2].NumberOfRedShape.ToString(), _order.OrderedBlocks[2].NumberOfBlueShape.ToString(), _order.OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
    }
}
