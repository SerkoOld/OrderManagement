namespace Order.Management
{
    internal class Circle : Shape
    {
        private const int CirclePrice = 3;
        public Circle(int numberOfRedCircles, int numberOfBlueCircles, int numberOfYellowCircles) 
            :base(numberOfRedCircles, numberOfBlueCircles, numberOfYellowCircles)
        {
            Name = "Circle";
            Price = CirclePrice;
            AdditionalCharge = 1;
        }

        public override int Total()
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        public int RedCirclesTotal()
        {
            return NumberOfRedShape * Price;
        }
        public int BlueCirclesTotal()
        {
            return NumberOfBlueShape * Price;
        }
        public int YellowCirclesTotal()
        {
            return NumberOfYellowShape * Price;
        }
    }
}