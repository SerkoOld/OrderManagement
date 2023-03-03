using Order.Management.Models;

namespace Order.Management.Services
{
  public interface IPrinter
  {
    public string PrintInvoice(OrderInfo order, IPricing pricing);
    public string PrintCuttingJob(OrderInfo order);
    public string PrintPaintingJob(OrderInfo order);
  }

}
