using System;
using System.Collections.Generic;
using System.Linq;
using Order.Management.Models;

namespace Order.Management.Services
{

  // This is a collection of functions that generate reports
  public static class Report
  {
    public static Models.Invoice GenerateInvoice(OrderInfo order, IPricing pricing)
    {
      decimal total = 0;
      var items = new Dictionary<string, InvoiceItem>();
      var surcharges = new Dictionary<string, InvoiceItem>();
      foreach (var item in order.Items)
      {
        // generate cutting price
        var shapeName = item.Shape.ToString();
        var cuttingPrice = pricing.GetPrice(item.Shape);
        var cuttingItem = items.GetValueOrDefault(shapeName, new InvoiceItem()
        {
          Name = shapeName,
          Price = cuttingPrice,
          Quantity = 0,
          Sum = 0,
        });
        cuttingItem.Quantity += 1;
        cuttingItem.Sum += cuttingPrice;
        items[shapeName] = cuttingItem;
        total += cuttingPrice;

        // generate color surcharge
        var surcharge = pricing.GetPrice(item.Color);
        if (surcharge <= 0) continue;
        var surchargeItem = surcharges.GetValueOrDefault(item.Color.ToString(), new InvoiceItem()
        {
          Name = $"{item.Color} color surcharge",
          Price = surcharge,
          Quantity = 0,
          Sum = 0,
        });
        surchargeItem.Quantity += 1;
        surchargeItem.Sum += surcharge;
        total += surcharge;
        surcharges[item.Color.ToString()] = surchargeItem;
      }

      return new Models.Invoice()
      {
        Items = items.Values.Concat(surcharges.Values).ToArray(),
        Total = total,
      };
    }

    public static (ToyShape, int)[] GenerateCuttingList(OrderInfo order)
    {
      var job = new Dictionary<ToyShape, int>();
      foreach (var item in order.Items)
      {
        var count = job.GetValueOrDefault(item.Shape, 0);
        job[item.Shape] = count + 1;
      }

      return job.Select(item => (item.Key, item.Value)).ToArray();
    }

    public static Matrix<ToyShape, ToyColor, int> GenerateMatrix(OrderInfo orderInfo)
    {
      throw new NotImplementedException();
    }
  }
}
