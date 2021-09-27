using Microsoft.VisualBasic.CompilerServices;
using Order.Management.Enums;
using Order.Management.Exceptions;

namespace Order.Management
{
    public static class Constants
    {
        // Constants for Reports
        public const int TableWidth = 73;
        public const int CuttingReportTableWidth = 20;

        // Constants for Orders
        public const decimal CirclePrice = 3m;
        public const decimal SquarePrice = 1m;
        public const decimal TrianglePrice = 2m;
        public const decimal AdditionalCharge = 1m;

        public static Shapes[] CurrentShapes = new[]
        {
            Shapes.Square,
            Shapes.Triangle,
            Shapes.Circle,
        };

        public static ShapeColours[] CurrentColours = new[]
        {
            ShapeColours.Red,
            ShapeColours.Blue,
            ShapeColours.Yellow,
        };
    }
}