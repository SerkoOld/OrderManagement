using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class ShapeFactory
    {
        private readonly string _name = "";
        public abstract Shape CreateShape(Dictionary<Color, int> colorNumbers);
        public virtual string Name { get { return _name; } }
    }
}
