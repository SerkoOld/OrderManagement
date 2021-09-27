using System;
using System.Collections.Generic;
using Order.Management.Enums;
using Order.Management.Models;

namespace Order.Management
{
    public static class Program
    {
        // Main entry
        public static void Main(string[] args)
        {
            var (customerName, address, dueDate) = CustomerInfoInput();

            var orderedShapes = CustomerOrderInput();
            var order = new Models.Order()
            {
                Address = address,
                CustomerName = customerName,
                DueDate = dueDate,
                OrderedBlocks = orderedShapes,
            };

            ShowInvoiceReport(order);

            ShowCuttingListReport(order);

            ShowPaintingReport(order);
        }

        // User Console Input
        private static string UserInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();
            }

            return input;
        }

        // Generate Painting Report
        private static void ShowPaintingReport(Models.Order order)
        {
            PaintingReport paintingReport = new PaintingReport(order);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report
        private static void ShowCuttingListReport(Models.Order order)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(order);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report
        private static void ShowInvoiceReport(Models.Order order)
        {
            InvoiceReport invoiceReport = new InvoiceReport(order);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static (string customerName, string address, string dueDate) CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = UserInput();
            Console.Write("Please input your Address: ");
            string address = UserInput();
            Console.Write("Please input your Due Date: ");
            string dueDate = UserInput();
            return (customerName, address, dueDate);
        }

        // Get order input
        private static List<OrderItem> CustomerOrderInput()
        {
            var orderItemList = new List<OrderItem>();
            foreach(var shape in Constants.CurrentShapes)
            foreach (ShapeColours colour in Constants.CurrentColours)
            {
                Console.Write($"\nPlease input the number of {colour} {shape}: ");
                int quantity = Convert.ToInt32(UserInput());
                orderItemList.Add(new OrderItem()
                {
                    Shape = new Shape(shape, colour),
                    Quantity = quantity
                });
            }
            return orderItemList;
        }
    }
}