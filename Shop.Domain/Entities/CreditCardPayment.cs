using System;
using Shop.Domain.ValueObjects;

namespace Shop.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName, string cardLastNumbers,
        string lastTransactionNumber, DateTime paidDate, DateTime expiredDate, decimal total,
        decimal totalPaid, TDocument document, string owner, Address address, TEmail email) :
        base(paidDate, expiredDate, total, totalPaid, document, owner, address, email)
        {
            CardHolderName = cardHolderName;
            CardLastNumbers = cardLastNumbers;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardLastNumbers { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}
