namespace Order.Management
{
    class Circle : Shape
    {
        public Circle(int red, int blue, int yellow)
        {
            base.NumberOfRedShape = red;
            base.NumberOfBlueShape = blue;
            base.NumberOfYellowShape = yellow;
        }
        public override int Price { get => 3; }
        
        public override string Name { get => "Circle"; }

        public override int Total()
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        public int RedCirclesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public int BlueCirclesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowCirclesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
