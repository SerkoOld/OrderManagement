namespace Order.Management
{
    public class ToyInfo
    {
        public Shape Shape { get; set; }
        public Color Color { get; set; }
        public int Quantity { get; set; }
    }

    public enum Shape
    {
        Square,
        Triangle,
        Circle
    }

    public enum Color
    {
        Red,
        Blue,
        Yellow
    }
}
