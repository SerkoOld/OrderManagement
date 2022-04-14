using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class InvoiceReport : Report
    {
        public int tableWidth = 73;
        Order order = new Order();
        public InvoiceReport(string customerName, string address, string dueDate, List<Order> shapes)
        {
            order.CustomerName = customerName;
            order.Address = address;
            order.DueDate = dueDate;
            order.OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            Circle circle = new Circle();
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + circle.AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            return order.OrderedBlocks[0].NumberOfColorShape["Red"] + order.OrderedBlocks[1].NumberOfColorShape["Red"] +
                   order.OrderedBlocks[2].NumberOfColorShape["Red"];
        }

        public int TotalPriceRedPaintSurcharge()
        {
            Circle circle = new Circle(); 
            return TotalAmountOfRedShapes() * circle.AdditionalCharge;
        }
        public void GenerateTable()
        {
            PrintLine(tableWidth);
            PrintRow(tableWidth, "        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine(tableWidth);
            PrintRow(tableWidth, "Square", order.OrderedBlocks[0].NumberOfColorShape["Red"].ToString(), order.OrderedBlocks[0].NumberOfColorShape["Blue"].ToString(), order.OrderedBlocks[0].NumberOfColorShape["Yellow"].ToString());
            PrintRow(tableWidth, "Triangle", order.OrderedBlocks[1].NumberOfColorShape["Red"].ToString(), order.OrderedBlocks[1].NumberOfColorShape["Blue"].ToString(), order.OrderedBlocks[1].NumberOfColorShape["Yellow"].ToString());
            PrintRow(tableWidth, "Circle", order.OrderedBlocks[2].NumberOfColorShape["Red"].ToString(), order.OrderedBlocks[2].NumberOfColorShape["Blue"].ToString(), order.OrderedBlocks[2].NumberOfColorShape["Yellow"].ToString());
            PrintLine(tableWidth);
        }
        //OrderXXXDetails can be merged as one method by passing parameters, e.g.OrderShapeDetails(shape)
        public void OrderSquareDetails()
        {
            Square square = new Square();
            Console.WriteLine("\nSquares 		  " + order.OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + square.Price + " ppi = $" + square.Total(order.OrderedBlocks[0]));
        }
        public void OrderTriangleDetails()
        {
            Triangle triangle = new Triangle();
            Console.WriteLine("Triangles 		  " + order.OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + triangle.Price + " ppi = $" + triangle.Total(order.OrderedBlocks[1]));
        }
        public void OrderCircleDetails()
        {
            Circle circle = new Circle();
            Console.WriteLine("Circles 		  " + order.OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + circle.Price + " ppi = $" + circle.Total(order.OrderedBlocks[2]));
        }
    }
}
