    using System;
using Volo.Abp.Domain.Entities;

namespace ModuleTopic6.Products
{
    public class Product : Entity<Guid>
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public float PurchasePrice { get; set; }
    }
}
