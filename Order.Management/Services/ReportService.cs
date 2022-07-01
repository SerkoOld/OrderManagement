using System;
using Order.Management.Domain;
using Order.Management.Enums;

namespace Order.Management.Services
{
    public class ReportService : BaseReport
    {
        public ReportService(OrderInfo orderInfo) : base(orderInfo)
        {
        }
        public override void GenerateReport(Enum reportType)
        {
            try
            {
                switch (reportType) {
                    case ReportType.Invoice:
                        Console.WriteLine("\nYour invoice report has been generated: ");
                        Console.WriteLine(orderInfo.ToMessage());
                        GenerateTable();
                        Console.WriteLine();
                        ShowOrderDetailsByShape();
                        ShowRedColorSurcharge();
                        ShowTotalCharge();
                        break;
                    case ReportType.CuttingList:
                        SetTableWidth(20);
                        Console.WriteLine("\nYour cutting list has been generated: ");
                        Console.WriteLine(orderInfo.ToMessage());
                        GenerateCuttingListTable();
                        break;
                    case ReportType.Painting:
                        SetTableWidth(73);
                        Console.WriteLine("\nYour painting report has been generated: ");
                        Console.WriteLine(orderInfo.ToMessage());
                        GenerateTable();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nPrint report exception: " + ex.Message.ToString());
            }
        }

        private void ShowOrderDetailsByShape()
        {
  
            foreach (var shape in Util.Util.ShapeList)
            {
                int shapeNumber = orderInfo.GetCountByShape(shape);
                decimal unitPrice = orderInfo.GetShapePrice(shape);
                Console.WriteLine(
                    $"{shape}s 		  {shapeNumber} @ ${unitPrice} ppi = ${shapeNumber * unitPrice}");
            }
        }

        private void ShowRedColorSurcharge()
        {
            int RedColorNumber = orderInfo.GetCountByColor(Color.Red);
            Console.WriteLine(
                    $"Red Color Surcharge       {orderInfo.GetCountByColor(Color.Red)} @ ${ToyPrice.ExtraChargesWithRed} ppi = ${RedColorNumber * ToyPrice.ExtraChargesWithRed}");
        }

        private void ShowTotalCharge()
        {
            int RedColorNumber = orderInfo.GetCountByColor(Color.Red);
            decimal totalPrice = 0;
            foreach (var shape in Util.Util.ShapeList)
            {
                int shapeNumber = orderInfo.GetCountByShape(shape);
                decimal unitPrice = orderInfo.GetShapePrice(shape);
                totalPrice += unitPrice * shapeNumber;
            }
            PrintLine();
            Console.WriteLine(
                    $"Total        ${totalPrice + RedColorNumber * ToyPrice.ExtraChargesWithRed}");
        }

        private void GenerateCuttingListTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();

            foreach (Enum shape in Util.Util.ShapeList)
            {
                PrintRow(shape, orderInfo.GetCountByShape(shape));
            }
            PrintLine();
        }
    }
}
