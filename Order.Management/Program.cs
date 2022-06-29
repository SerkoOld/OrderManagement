using System;
using System.Collections.Generic;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            var (customerName, address, dueDate) = CustomerInfoInput();

            var orderedInfo = CustomerOrderInput();

            var order = new Order()
            {
                Address = address,
                CustomerName = customerName,
                DueDate = dueDate,
                OrderNumber = GenerateOrderNumber(),
                ToyInfos = orderedInfo
            };

            InvoiceReport(order);

            CuttingListReport(order);

            PaintingReport(order);
        }

        #region Customer/Order Info input

        // Get customer Info
        private static (string customerName, string address, DateTime dueDate) CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = UserStringInput();
            Console.Write("Please input your Address: ");
            string address = UserStringInput();
            Console.Write("Please input your Due Date: ");
            DateTime dueDate = UserDateInput();
            return (customerName, address, dueDate);
        }

        // Get order input
        private static List<ToyInfo> CustomerOrderInput()
        {
            var orderBlocks = new List<ToyInfo>();
            foreach (var shape in CommonConst.ShapeList)
            {
                Console.Write($"\n");
                foreach (Color color in CommonConst.ColorList)
                {
                    Console.Write($"Please input the number of {color} {shape}: ");
                    int quantity = UserNumberInput();
                    orderBlocks.Add(new ToyInfo()
                    {
                        Shape = shape,
                        Color = color,
                        Quantity = quantity
                    });
                }
            }
            return orderBlocks;
        }

        // User Console String Input
        private static string UserStringInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();

            }
            return input;
        }

        // User Console Date Input
        private static DateTime UserDateInput()
        {
            string input = Console.ReadLine();
            DateTime dueDate;
            while (!DateTime.TryParse(input, out dueDate))
            {
                Console.WriteLine("please enter a valid Date");
                input = Console.ReadLine();
            }
            return dueDate; 
        }

        // User Console Number Input
        private static int UserNumberInput()
        {
            string input = Console.ReadLine();
            int inputNumber;

            if(string.IsNullOrWhiteSpace(input))
            {
                input = "0";
            }

            while (!Int32.TryParse(input, out inputNumber))
            {
                Console.WriteLine("please enter a valid number");
                input = Console.ReadLine();

            }
            return inputNumber;
        }

        //Generate a Random Order Number
        private static int GenerateOrderNumber()
        {
            return new Random().Next();
        }

        #endregion

        #region Generate Report

        // Generate Painting Report 
        private static void PaintingReport(Order order)
        {
            PaintingReport paintingReport = new PaintingReport(order);
            paintingReport.GenerateReport();
        }

        // Generate Cutting List Report 
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

        #endregion
    }
}
