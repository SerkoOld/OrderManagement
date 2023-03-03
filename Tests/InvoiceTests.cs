using System;
using System.Collections.Generic;
using NUnit.Framework;
using Order.Management.Models;
using Order.Management.Services;

namespace Tests
{
  [TestFixture]
  public class InvoiceTests
  {
    [Test]
    public void TestInvoiceCreation()
    {
      var order = new OrderInfo()
      {
        Name = "John Doe",
        Address = "123 Main St",
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

      var invoice = Report.GenerateInvoice(order, new DefaultPricing());
      Assert.AreEqual(1, 1);
      var expectedItems = new[]
      {
        new InvoiceItem()
        {
          Name = "Square",
          Price = 1,
          Quantity = 2,
          Sum = 2,
        },
        new InvoiceItem()
        {
          Name = "Triangle",
          Price = 2,
          Quantity = 2,
          Sum = 4,
        },
        new InvoiceItem()
        {
          Name = "Circle",
          Price = 3,
          Quantity = 3,
          Sum = 9,
        },
        new InvoiceItem()
        {
          Name = "Red color surcharge",
          Price = 1,
          Quantity = 1,
          Sum = 1,
        },
      };

      Assert.AreEqual(expectedItems, invoice.Items);
      Assert.AreEqual(16, invoice.Total);
    }
  }
}
