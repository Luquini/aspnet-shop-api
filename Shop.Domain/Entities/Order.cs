using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Enums;

namespace Shop.Domain.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            CreateDate = DateTime.Now;
            Status = EShopStatus.Created;
            _items = new List<OrderItem>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EShopStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();

        void Place() { }

        public void AddItem(OrderItem item)
        {
            //validation
            _items.Add(item);
        }
    }
}
