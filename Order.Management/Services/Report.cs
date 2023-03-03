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
      throw new NotImplementedException();
    }

    public static (ToyShape, int)[] GenerateCuttingList(OrderInfo order)
    {
      throw new NotImplementedException();
    }

    public static Matrix<ToyShape, ToyColor, int> GenerateMatrix(OrderInfo orderInfo)
    {
      throw new NotImplementedException();
    }
  }
}
