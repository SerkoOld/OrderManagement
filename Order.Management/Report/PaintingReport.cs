using System;

namespace Order.Management
{
    class PaintingReport : BaseReport
    {
        public PaintingReport(Order order) : base(order)
        {
        }
        
        public override void GenerateReport()
        {
            try
            {
                Console.WriteLine("\nYour painting report has been generated: ");
                Console.WriteLine(order.ToString());
                GenerateTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nPrint painting report exception: " + ex.Message.ToString());
            }
        }
    }
}
