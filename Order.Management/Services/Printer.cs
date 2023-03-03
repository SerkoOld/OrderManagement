using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order.Management.Models;

namespace Order.Management.Services
{
  public interface IPrinter
  {
    public string PrintInvoice(OrderInfo order, IPricing pricing);
    public string PrintCuttingJob(OrderInfo order);
    public string PrintPaintingJob(OrderInfo order);
  }

  public class MarkdownPrinter : IPrinter
  {
    public string PrintInvoice(OrderInfo order, IPricing pricing)
    {
      var report = new StringBuilder();
      report.AppendLine(PrintCustomerInfo(order));
      var matrix = Report.GenerateMatrix(order);
      report.AppendLine(PrintTable(matrix));
      var invoice = Report.GenerateInvoice(order, pricing);
      foreach (var item in invoice.Items)
      {
        report.AppendLine($"{item.Name} {item.Quantity} @ ${item.Price} ppi = ${item.Sum}");
      }
      report.AppendLine($"Total: ${invoice.Total}");
      return report.ToString();
    }

    public string PrintCuttingJob(OrderInfo order)
    {
      var report = new StringBuilder();
      report.AppendLine(PrintCustomerInfo(order));
      var list = Report.GenerateCuttingList(order);
      report.AppendLine(PrintTable(list, "Shape", "Qty"));
      return report.ToString();
    }

    public string PrintPaintingJob(OrderInfo order)
    {
      var report = new StringBuilder();
      report.AppendLine(PrintCustomerInfo(order));
      var matrix = Report.GenerateMatrix(order);
      report.AppendLine(PrintTable(matrix));
      return report.ToString();
    }

    private static string PrintCustomerInfo(OrderInfo order)
    {
      return $"Name: {order.Name} Address: {order.Address} Due Date: {order.DueDate} Order #: {order.OrderNumber}";
    }

    private static string PrintTable(IEnumerable<(ToyShape, int)> tuples, string kLabel, string vLabel)
    {
      var table = new StringBuilder();
      table.AppendFormat("| {0} | {1} |", kLabel, vLabel);
      table.AppendLine();
      table.AppendLine($"| {new string('-', kLabel.Length)} | {new string('-', vLabel.Length)} |");
      foreach (var (shape, count) in tuples)
      {
        table.AppendFormat("| {0} | {1} |", shape, count);
        table.AppendLine();
      }

      return table.ToString();
    }

    private static string PrintTable<TR, TC>(Matrix<TR, TC, int> matrix)
    {
      var table = new StringBuilder();
      table.AppendLine($"|     | {string.Join(" | ", matrix.Columns)} |");
      var separators = matrix.Columns.Select(c => new string('-', c.ToString().Length));
      table.AppendLine($"| --- | {string.Join(" | ", separators)} |");
      foreach (var row in matrix.Rows)
      {
        table.AppendFormat("| {0} | {1} |", row, string.Join(" | ", matrix.Columns.Select(c => matrix[row, c])));
        table.AppendLine();
      }
      return table.ToString();
    }
  }
}
