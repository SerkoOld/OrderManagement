
namespace Order.Management
{
    class Square : Shape
    {
        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        :base (numberOfRedSquares,numberOfBlueSquares,numberOfYellowSquares){
            Name = "Square";
            this.Price = 1;
        }
    }
}
