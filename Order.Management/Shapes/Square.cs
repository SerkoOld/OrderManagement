namespace Order.Management
{
    public class Square : Shape
    {
        public const int SquarePrice = 1;
        public const string SquareName = "Square";

        public Square(int redAmount, int blueAmount, int yellowAmount) : base(redAmount, blueAmount, yellowAmount)
        {
            Name = SquareName;
            Price = SquarePrice;
        }
    }
}
