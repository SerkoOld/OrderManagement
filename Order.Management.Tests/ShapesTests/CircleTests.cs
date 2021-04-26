using Order.Management.Exceptions;
using Order.Management.Shapes;
using Xunit;

namespace Order.Management.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        public void CreateCircleWithNegativeParameters_ShouldThrowShapeNumberIsNegativeException(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            Assert.Throws<ShapeNumberIsNegativeException>(() => new Circle(numberOfRedShape, numberOfBlueShape, numberOfYellowShape));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 1, 1)]
        public void CreateCircleWithNonNegativeParameters_ShouldSucceed(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            var circle = new Circle(numberOfRedShape, numberOfBlueShape, numberOfYellowShape);
        }

        [Fact]
        public void CreateCircle_CirclePriceShouldBeThree()
        {
            //Arrange
            const int expectedCirclePrice = 3;

            //Act
            var circle = new Circle(0, 0, 0);

            //Assert
            Assert.Equal(expectedCirclePrice, circle.Price);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateCircleWithGivenRedCirclesNumber_ShouldHaveExpectedRedCircleNumber(int redCirclesNumber)
        {
            //Arrange
            //Act
            var circle = new Circle(redCirclesNumber, 0, 0);

            //Assert
            Assert.Equal(redCirclesNumber, circle.NumberOfRedShape);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateCircleWithGivenBlueCirclesNumber_ShouldHaveExpectedRedCircleNumber(int blueCirclesNumber)
        {
            //Arrange
            //Act
            var circle = new Circle(0, blueCirclesNumber, 0);

            //Assert
            Assert.Equal(blueCirclesNumber, circle.NumberOfBlueShape);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateCircleWithGivenYellowCirclesNumber_ShouldHaveExpectedRedCircleNumber(int yellowCirclesNumber)
        {
            //Arrange
            //Act
            var circle = new Circle(0, 0, yellowCirclesNumber);

            //Assert
            Assert.Equal(yellowCirclesNumber, circle.NumberOfYellowShape);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 0, 1)]
        [InlineData(0, 1, 0, 1)]
        [InlineData(0, 0, 1, 1)]
        [InlineData(1, 1, 1, 3)]
        public void CreateCircleWithGivenColorNumbers_ShouldHaveExpectedTotalQuantityOfShape(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape, int expectedTotalNumber)
        {
            //Arrange
            //Act
            var circle = new Circle(numberOfRedShape, numberOfBlueShape, numberOfYellowShape);

            //Assert
            Assert.Equal(expectedTotalNumber, circle.TotalQuantityOfShape());
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        public void CreateCirclesWithoutRedColor_RedColorChargeTotalShoudBeZero(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            //Arrange
            const int expectedRedColorChargeTotal = 0;

            //Act
            var circle = new Circle(numberOfRedShape, numberOfBlueShape, numberOfYellowShape);

            //Assert
            Assert.Equal(expectedRedColorChargeTotal, circle.RedColorChargeTotal());
        }

        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 2)]
        public void CreateCirclesWithRedColor_ShoudHaveExpectedRedColorChargeTotal(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            //Arrange
            const int redColorSurcharge = 1;
            var expectedRedColorChargeTotal = numberOfRedShape * redColorSurcharge;

            //Act
            var circle = new Circle(numberOfRedShape, numberOfBlueShape, numberOfYellowShape);

            //Assert
            Assert.Equal(expectedRedColorChargeTotal, circle.RedColorChargeTotal());
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 1, 1)]
        public void CreateCirclesCreateCircleWithGivenColorNumbers_ShouldHaveExpectedTotal(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            //Arrange
            const int circlePrice = 3;
            var expectedTotal = (numberOfRedShape + numberOfBlueShape + numberOfYellowShape) * circlePrice;

            //Act
            var circle = new Circle(numberOfRedShape, numberOfBlueShape, numberOfYellowShape);

            //Assert
            Assert.Equal(expectedTotal, circle.Total());
        }
    }
}
