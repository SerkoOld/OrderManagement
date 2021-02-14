using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class PaintingReport : Order
    {
        public PaintingReport(CustomerInfo customerInfo, List<Shape> shapes) : base(customerInfo, shapes)
        {      
        }

        public override string ReportType => "Painting";
    }
}
