using Order.Management.Reports;

namespace Order.Management
{
    public static class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            var customerInput = new CustomerInfo();

            var (customerName, address, dueDate) = customerInput.CustomerInfoInput();

            var orderedShapes = customerInput.CustomerOrderInput();

            var order = new Order
            {
                CustomerName = customerName,
                Address = address,
                DueDate = dueDate,
                OrderedShapes = orderedShapes
            };

            InvoiceReport(order);

            CuttingListReport(order);

            PaintingReport(order);
        }


        // Generate Painting Report
        private static void PaintingReport(Order order)
        {
            PaintingReport paintingReport = new PaintingReport(order);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report
        private static void CuttingListReport(Order order)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(order);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report
        private static void InvoiceReport(Order order)
        {
            InvoiceReport invoiceReport = new InvoiceReport(order);
            invoiceReport.GenerateReport();
        }
    }
}
