namespace Order.Management
{
    public class Circle : Shape
    {
        public const int circlePrice = 3;
        public const string CircleName = "Circle";

        public Circle(int redAmount, int blueAmount, int yellowAmount) : base(redAmount, blueAmount, yellowAmount)
        {
            Name = CircleName;
            Price = circlePrice;
        }
    }
}
