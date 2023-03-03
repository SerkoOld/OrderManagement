using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Order.Management.Services;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Toy Block Factory!");
            var order = Prompt.Run();
            if (order == null)
            {
              Console.WriteLine("Order is cancelled");
              return;
            }
            Console.WriteLine("Order is completed");
            var printer = new MarkdownPrinter();
            var invoice = printer.PrintInvoice(order.Value, new DefaultPricing());
            Console.WriteLine("Your invoice report has been generated:");
            Console.WriteLine(invoice);
            var cuttingJob = printer.PrintCuttingJob(order.Value);
            Console.WriteLine("Your cutting list has been generated:");
            Console.WriteLine(cuttingJob);
            var paintingJob = printer.PrintPaintingJob(order.Value);
            Console.WriteLine("Your painting report has been generated:");
            Console.WriteLine(paintingJob);
        }
    }
}
