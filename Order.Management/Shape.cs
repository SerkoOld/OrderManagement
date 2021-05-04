using System.Collections.Generic;
using System.Linq;

namespace Order.Management
{
    public abstract class Shape
    {
        protected Shape(List<ShapeVariant> shapeVariants)
        {
            ShapeVariants = shapeVariants;
        }

        internal string Name { get; set; }
        internal int Price { get; set; }
        protected List<ShapeVariant> ShapeVariants { get; set; }

        public int TotalQuantityOfShape()
        {
            return ShapeVariants?.Sum(v => v.Qty) ?? 0;
        }

        public int AdditionalChargeQty()
        {
            return (ShapeVariants?.Where(v => v.AdditionalCharge).Sum(v => v.Qty) ?? 0);
        }

        public int AdditionalChargeTotal()
        {
            return (ShapeVariants?.Where(v => v.AdditionalCharge).Sum(v => v.Qty) ?? 0) * Constants.AdditionalCharge;
        }

        public int TotalQtyByShapeColor(ShapeColors shapeColor)
        {
            return (ShapeVariants?.Where(v => v.ShapeColor == shapeColor).Sum(v => v.Qty) ?? '-');
        }

        public int Total()
        {
            return (ShapeVariants?.Sum(v => v.Qty) ?? 0) * Price;
        }

    }
}