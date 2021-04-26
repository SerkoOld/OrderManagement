using System;

namespace Order.Management.Exceptions
{
    public class ShapeNumberIsNegativeException : Exception
    {
        public ShapeNumberIsNegativeException() : base("Shape number cannot be negative") { }
    }
}
