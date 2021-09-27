using System.Collections.Generic;
using System.Management;
using System.Runtime.InteropServices;
using Order.Management.Enums;
using Xunit;
using Order.Management.Models;

namespace Order.Management.Test
{
    public class OrderTest
    {
        public static IEnumerable<object[]> OrderWithColorTotalData =>
            GetSampleOrderList(QuantitySample, QuantityTotalByColorSample);

        public static IEnumerable<object[]> OrderWithShapeTotalData =>
            GetSampleOrderList(QuantitySample, QuantityTotalByShapeSample);


        [Theory]
        [MemberData(nameof(OrderWithColorTotalData))]
        void OrderColorTotalTestTheory(Models.Order order, int[] expectTotalByColor)
        {
            int red = expectTotalByColor[0];
            int blue = expectTotalByColor[1];
            int yellow = expectTotalByColor[2];
            Assert.Equal(order.GetNumbersOfColour(ShapeColours.Red), red);
            Assert.Equal(order.GetNumbersOfColour(ShapeColours.Blue), blue);
            Assert.Equal(order.GetNumbersOfColour(ShapeColours.Yellow), yellow);
        }

        [Theory]
        [MemberData(nameof(OrderWithShapeTotalData))]
        void OrderShapeTotalTestTheory(Models.Order order, int[] expectTotalByShape)
        {
            int squareTotal = expectTotalByShape[0];
            int triangleTotal = expectTotalByShape[1];
            int circleTotal = expectTotalByShape[2];
            Assert.Equal(order.GetNumbersOfShape(Shapes.Square), squareTotal);
            Assert.Equal(order.GetNumbersOfShape(Shapes.Triangle), triangleTotal);
            Assert.Equal(order.GetNumbersOfShape(Shapes.Circle), circleTotal);
        }

        private static int[][] QuantitySample { get; } =
        {
            new[]
            {
                //Red, Blue, Yellow
                1, 2, 3, //square
                4, 7, 2, //triangle
                5, 8, 1, //circle
            },
            new[]
            {
                //Red, Blue, Yellow
                1, 2, 3,
                2, 5, 6,
                3, 8, 1,
            },
            new[]
            {
                //Red, Blue, Yellow
                0, 3, 4,
                1, 5, 8,
                9, 2, 3,
            },
        };

        private static int[][] QuantityTotalByColorSample { get; } =
        {
            new[]
            {
                //Red, Blue, Yellow
                10, 17, 6,
            },
            new[]
            {
                //Red, Blue, Yellow
                6, 15, 10,
            },
            new[]
            {
                //Red, Blue, Yellow
                10, 10, 15,
            },
        };

        private static int[][] QuantityTotalByShapeSample { get; } =
        {
            new[]
            {
                //Square, Triangle, Circle
                6, 13, 14,
            },
            new[]
            {
                //Square, Triangle, Circle
                6, 13, 12,
            },
            new[]
            {
                //Square, Triangle, Circle
                7, 14, 14,
            },
        };

        private static IEnumerable<object[]> GetSampleOrderList(int[][] quantitySample, int[][] quantityTotalSample)
        {
            var index = 0;
            foreach (var quantityList in quantitySample)
            {
                var order = new Models.Order
                {
                    CustomerName = "David Wei",
                    Address = "21 Stanbury Avenue, Somerfield, Christchurch 8024",
                    DueDate = "28-09-2021",
                    OrderNumber = 1000,
                    OrderedBlocks = GetSampleOrderItemList(quantityList)
                };
                yield return new object[] {order, quantityTotalSample[index]};
                index++;
            }
        }

        private static List<OrderItem> GetSampleOrderItemList(int[] quantityList)
        {
            var orderItemList = new List<OrderItem>();
            var quantityIndex = 0;
            foreach (var shape in Constants.CurrentShapes)
            foreach (ShapeColours colour in Constants.CurrentColours)
            {
                var quantity = quantityList[quantityIndex];
                orderItemList.Add(new OrderItem()
                {
                    Shape = new Shape(shape, colour),
                    Quantity = quantity,
                });
                quantityIndex++;
            }

            return orderItemList;
        }
    }
}