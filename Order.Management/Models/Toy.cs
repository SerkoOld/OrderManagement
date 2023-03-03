namespace Order.Management.Models
{
  public struct Toy
  {

    public ToyShape Shape;
    public ToyColor Color;

    public Toy(ToyShape shape, ToyColor color)
    {
      Shape = shape;
      Color = color;
    }
  }
}
