using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Queries
{
    public class GetCustomerQueryResult
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Document { get; set; }
        public string? Email { get; set; }
    }
}