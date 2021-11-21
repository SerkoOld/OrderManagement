
namespace Order.Management
{
    class PaintingReport : Report
    {
        public PaintingReport(Order order, int tableWidth)
        : base(order, "painting", tableWidth)
        {
        }
    }
}
