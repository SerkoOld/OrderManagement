using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class InvoiceReport : Order
    {
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = shapes;
            ReportTableWidth = 73;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(ReportSummaryHeader());
            GenerateReportDetail("        ", "   Red   ", "  Blue  ", " Yellow ");

            foreach (var orderedBlock in OrderedBlocks)
            {
                Console.WriteLine(string.Format("\n{0} {1} @ ${2} ppi = ${3}",
                            orderedBlock.Name,
                            orderedBlock.TotalQuantityOfShape().ToString(),
                            orderedBlock.Price.ToString(),
                            orderedBlock.Total().ToString()));

                Console.WriteLine(string.Format("Red Color Surcharge {0} @ ${1} ppi = ${2}",
                                            orderedBlock.NumberOfRedShape,
                                            orderedBlock.AdditionalCharge,
                                            (orderedBlock.NumberOfRedShape * orderedBlock.AdditionalCharge) ));

            }

            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            Console.WriteLine(string.Format("\nRed Color Surcharge Total {0} ppi = ${1}",
                                        TotalAmountOfRedShapes().ToString(),
                                        TotalPriceRedPaintSurcharge().ToString() ));
        }

        public int TotalAmountOfRedShapes()
        {
            int redShapesTotal = 0;
            foreach (var orderedBlock in OrderedBlocks)
            {
                redShapesTotal += orderedBlock.NumberOfRedShape;
            }
            return redShapesTotal; 
        }

        public int TotalPriceRedPaintSurcharge()
        {
            int paintSurchargeTotal = 0;
            foreach (var orderedBlock in OrderedBlocks)
            {
                paintSurchargeTotal += (orderedBlock.NumberOfRedShape * orderedBlock.AdditionalCharge);
            }
            return paintSurchargeTotal;
        }

    }
}
