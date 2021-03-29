namespace Order.Management
{
    internal class Circle : Shape
    {
        private const int CirclePrice = 3; 
        private const string CircleName = "Circle";
        public Circle(int amountOfRed, int amountOfBlue, int amountOfYellow) : base(amountOfRed, amountOfBlue, amountOfYellow)
        {
            Name = CircleName;
            Price = CirclePrice;
        }
    }
}
