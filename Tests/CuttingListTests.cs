using System;
using System.Collections.Generic;
using NUnit.Framework;
using Order.Management.Models;
using Order.Management.Services;

namespace Tests
{
    [TestFixture]
    public class CuttingListTests
    {
        [Test]
        public void TestCuttingJobCreation()
        {
            var order = new OrderInfo()
            {
                Name = "John Doe",
                Address = "123 Main St",
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
