using System;

namespace Order.Management
{
    class CuttingListReport : BaseReport
    {
        private int _tableWidth = 20;

        public CuttingListReport(Order order) : base(order)
        {
        }

        public override void GenerateReport()
        {
            try
            {
                SetTableWidth(_tableWidth);
                Console.WriteLine("\nYour cutting list has been generated: ");
                Console.WriteLine(order.ToString());
                GenerateCuttingListTable();
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nPrint cutting list report exception: " + ex.Message.ToString());
            }
        }

        private void GenerateCuttingListTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();

            foreach (Enum shape in CommonConst.ShapeList)
            {
                PrintRow(shape, order.GetCountByShape(shape));
            }
            PrintLine();
        }
    }
}
