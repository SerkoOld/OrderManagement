using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class ShapeFactory
    {
        public abstract Shape CreateShape(Dictionary<Color, int> colorNumbers);
        public virtual string GetShapeName() 
        { 
            return ""; 
        }
    }
}
