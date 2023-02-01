using Order.Management.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class ReportGenerator
    {
        public ReportGenerator(ICustomer customer)
        {
            var reports = Helpers.GetAllSubclassOf(typeof(Order));
            foreach (var report in reports)
            {
                switch (report.Name)
                {
                    case nameof(CuttingListReport):
                        new CuttingListReport(customer).GenerateReport();
                        continue;
                    case nameof(PaintingReport):
                        new PaintingReport(customer).GenerateReport();
                        continue;
                    case nameof(InvoiceReport):
                        new InvoiceReport(customer).GenerateReport();
                        continue;
                    default:
                        throw new Exception("Error: Invalid report requested");
                }

            }
        }
    }

}
