using Order.Management.Services;
using Order.Management.Enums;

namespace Order.Management
{
    public class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            var orderService = new OrderService();
            var orderInfo = orderService.GetCustomerInput();
            var reportService = new ReportService(orderInfo);

            reportService.GenerateReport(ReportType.Invoice);
            reportService.GenerateReport(ReportType.CuttingList);
            reportService.GenerateReport(ReportType.Painting);

        }
    }
}
