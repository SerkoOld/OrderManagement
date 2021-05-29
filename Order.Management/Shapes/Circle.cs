namespace Order.Management.Shapes
{
    internal class Circle : Shape
    {
        private const int CirclePrice = 3;

        public Circle(int red, int blue, int yellow)
        {
            Price = CirclePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = red;
            NumberOfBlueShape = blue;
            NumberOfYellowShape = yellow;
        }
        public override int Total()
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        public int RedCirclesTotal()
        {
            return (NumberOfRedShape * Price);
        }
        public int BlueCirclesTotal()
        {
            return (NumberOfBlueShape * Price);
        }
        public int YellowCirclesTotal()
        {
            return (NumberOfYellowShape * Price);
        }
    }
}
