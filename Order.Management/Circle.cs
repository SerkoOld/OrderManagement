namespace Order.Management
{
    class Circle : Shape
    {
        public int circlePrice = 3;

        public Circle(int red, int blue, int yellow)
        {
            Name = "Circle";
            Price = circlePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = red;
            NumberOfBlueShape = blue;
            NumberOfYellowShape = yellow;
        }

        public override int Total => RedCirclesTotal+ BlueCirclesTotal+ YellowCirclesTotal;

        public int RedCirclesTotal => (NumberOfRedShape * Price);

        public int BlueCirclesTotal => (NumberOfBlueShape * Price);

        public int YellowCirclesTotal => (NumberOfYellowShape * Price);

    }
}
