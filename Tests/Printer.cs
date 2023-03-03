using System;
using System.Collections.Generic;
using NUnit.Framework;
using Order.Management.Models;
using Order.Management.Services;

// TODO: we can use snapshot testing to verify the output of printer
// currently we are just print them to console
namespace Tests
{
  [TestFixture]
  public class Printer
  {
    private OrderInfo _order;

    [SetUp]
    public void Setup()
    {
      _order = new OrderInfo()
      {
        Name = "John Doe",
        Address = "123 Main St",
        OrderNumber = 123,
        DueDate = DateTime.Now,
        Items = new List<Toy>
        {
          new Toy(ToyShape.Square, ToyColor.Red),
          new Toy(ToyShape.Square, ToyColor.Yellow),
          new Toy(ToyShape.Triangle, ToyColor.Blue),
          new Toy(ToyShape.Triangle, ToyColor.Blue),
          new Toy(ToyShape.Circle, ToyColor.Blue),
          new Toy(ToyShape.Circle, ToyColor.Yellow),
          new Toy(ToyShape.Circle, ToyColor.Yellow),
        },
      };
    }

    [Test]
    public void PrintCuttingReport()
    {
      var printer = new MarkdownPrinter();
      var report = printer.PrintCuttingJob(_order);
      Console.WriteLine(report);
      Assert.IsNotEmpty(report);
    }

    [Test]
    public void PrintPaintingReport()
    {
      var printer = new MarkdownPrinter();
      var report = printer.PrintPaintingJob(_order);
      Console.WriteLine(report);
      Assert.IsNotEmpty(report);
    }

    [Test]
    public void PrintInvoice()
    {
      var printer = new MarkdownPrinter();
      var report = printer.PrintInvoice(_order, new DefaultPricing());
      Console.WriteLine(report);
      Assert.IsNotEmpty(report);
    }
  }
}
