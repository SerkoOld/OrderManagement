using System;
using System.Collections.Generic;
using NUnit.Framework;
using Order.Management.Models;
using Order.Management.Services;
using Toy = Order.Management.Models.Toy;

namespace Tests
{
  [TestFixture]
  public class CuttingListReport
  {
    [Test]
    public void TestCuttingJobCreation()
    {
      var order = new OrderInfo()
      {
        Name = "John Doe",
        Address = "123 Main St",
        OrderNumber = 123,
        DueDate = DateTime.Now,
        Items = new List<Toy>
        {
          new Toy(ToyShape.Square, ToyColor.Red),
          new Toy(ToyShape.Circle, ToyColor.Blue),
          new Toy(ToyShape.Circle, ToyColor.Yellow),
        },
      };

      var list = Report.GenerateCuttingList(order);
      var expectedList = new[]
      {
        (ToyShape.Square, 1),
        (ToyShape.Circle, 2),
      };

      Assert.AreEqual(expectedList, list);
    }
  }
}
