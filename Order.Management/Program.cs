using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Management
{
    class Program
    {
        // Main entry 
        private static void Main(string[] args)
        {
            var (customerName, address, dueDate) = CustomerInfoInput();

            var orderedShapes = CustomerOrderInput();

            InvoiceReport(customerName, address, dueDate, orderedShapes);

            CuttingListReport(customerName, address, dueDate, orderedShapes);

            PaintingReport(customerName, address, dueDate, orderedShapes);
        }

        // Order Shape Input
        public static Shape OrderShapeInput(ShapeTypes shapeType)
        {
            var shapeVariants = ShapeVariants();

            Console.WriteLine();
            foreach (var variant in shapeVariants)
            {
                Console.Write($"Please input the number of {variant.ShapeColor.ToString()} {shapeType.ToString()}: ");
                int.TryParse(UserInput(allowEmptyInput: true), out var qty);
                variant.Qty = qty;
            }

            var shape = ShapeFactory.GetShape((int)shapeType, shapeVariants);
            return shape;
        }


        // User Console Input
        public static string UserInput(bool allowEmptyInput = false)
        {
            var input = Console.ReadLine();
            while (!allowEmptyInput && string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();
            }
            return input;
        }

        // Generate Painting Report 
        private static void PaintingReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            var paintingReport = new PaintingReport(customerName, address, dueDate, orderedShapes);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            var cuttingListReport = new CuttingListReport(customerName, address, dueDate, orderedShapes);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            var invoiceReport = new InvoiceReport(customerName, address, dueDate, orderedShapes);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static (string customerName, string address, string dueDate) CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            var customerName = UserInput();

            Console.Write("Please input your Address: ");
            var address = UserInput();

            Console.Write("Please input your Due Date: ");
            var dueDate = UserInput();

            return (customerName, address, dueDate);
        }

        // Get order input
        private static List<Shape> CustomerOrderInput()
        {
            var shapeTypes = Enum.GetValues(typeof(ShapeTypes)).Cast<ShapeTypes>();
            return shapeTypes.Select(OrderShapeInput).ToList();
        }

        // Generate Default Shape Variants
        public static List<ShapeVariant> ShapeVariants()
        {
            var shapeVariants = Enum.GetValues(typeof(ShapeColors)).Cast<ShapeColors>()
                .Select(v => new ShapeVariant(v, qty: 0, additionalCharge: v == ShapeColors.Red)).ToList();

            // additionalCharge: Is Additional Charge Flag to Identify Surcharge Variants

            return shapeVariants;
        }
    }
}
