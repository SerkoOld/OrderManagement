using System;

namespace Order.Management.Reports
{
    class CuttingListReport : BaseReport
    {
        protected override int TableWidth => 20;
        OrderDetails.Order _order;

        public CuttingListReport(OrderDetails.Order order)
        {
            _order = order;
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
            PrintRow("        ", "   Qty   ");
            PrintLine();
            PrintRow("Square", _order.OrderedBlocks[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", _order.OrderedBlocks[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", _order.OrderedBlocks[2].TotalQuantityOfShape().ToString());
            PrintLine();
        }
    }
}
