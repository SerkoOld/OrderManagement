using System;

namespace Order.Management
{
    public class Program
    {
        // Main entry
        public static void Main(string[] args)
        {
            var customerInfo = new CustomerInfo();
            customerInfo.CustomerInfoInput();
            customerInfo.CustomerOrderInput();
            var order = new Order(customerInfo);

            GenerateInvoiceReport(order);
            GenerateCuttingListReport(order);
            GeneratePaintingReport(order);

            Console.ReadLine();
        }

        // Generate Painting Report 
        private static void GeneratePaintingReport(Order order) // Rename the method name
        {
            PaintingReport paintingReport = new PaintingReport(order,73);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void GenerateCuttingListReport(Order order)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(order,20);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void GenerateInvoiceReport(Order order)
        {
            InvoiceReport invoiceReport = new InvoiceReport(order,73);
            invoiceReport.GenerateReport();
        }

    }
}
