
namespace Order.Management
{
    class PaintingReport : ReportBase
    {
        public PaintingReport(Order order, int tableWidth)
        : base(order, "painting", tableWidth)
        {
        }
    }
}
