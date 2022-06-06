using System;
using Shop.Domain.ValueObjects;

namespace Shop.Domain.Entities
{
  public class BoletoPayment : Payment
  {
    public BoletoPayment(string barcode, string boletoNumber, DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, TDocument document, string owner, Address address, TEmail email) :
    base(paidDate, expiredDate, total, totalPaid, document, owner, address, email)
    {
      Barcode = barcode;
      BoletoNumber = boletoNumber;
    }

    public string Barcode { get; private set; }
    public string BoletoNumber { get; private set; }
  }

}
