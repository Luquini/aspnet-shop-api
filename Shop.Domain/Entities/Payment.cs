using System;
using Shop.Domain.ValueObjects;
using Shop.Shared.Entities;

namespace Shop.Domain.Entities
{
  public abstract class Payment : Entity
  {
    protected Payment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, TDocument document, string owner, Address address, TEmail email)
    {
      Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
      PaidDate = paidDate;
      ExpiredDate = expiredDate;
      Total = total;
      TotalPaid = totalPaid;
      Document = document;
      Owner = owner;
      Address = address;
      Email = email;
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpiredDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public TDocument Document { get; private set; }
    public string Owner { get; private set; }
    public Address Address { get; private set; }
    public TEmail Email { get; private set; }
  }
}
