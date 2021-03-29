namespace Order.Management
{
    internal class Square : Shape
    {
        private const int SquarePrice = 1;
        private const string SquareName = "Square";

        public Square(int red, int blue, int yellow) : base(red, blue, yellow)
        {
            Name = SquareName;
            Price = SquarePrice;
        }
    }
}
