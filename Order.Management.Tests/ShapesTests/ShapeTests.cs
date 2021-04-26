using Xunit;

namespace Order.Management.Tests.ShapesTests
{
    public class ShapeTests
    {
        [Fact]
        public void RedColorSurchargeShouldBeOne()
        {
            //Arrange
            var expectedRedColorSurcharge = 1;

            //Act
            //Assert
            Assert.Equal(expectedRedColorSurcharge, Shapes.Shape.RedColorSurcharge);
        }

    }
}
