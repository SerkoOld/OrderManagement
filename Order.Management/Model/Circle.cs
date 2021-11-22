namespace Order.Management.Model
{
    class Circle : Shape
    {
        public Circle(int red, int blue, int yellow)
        {
            NumberOfRedShape = red;
            NumberOfBlueShape = blue;
            NumberOfYellowShape = yellow;
        }
        public override int Price { get => 3; }

        public override string Name { get => "Circle"; }

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
