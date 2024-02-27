using ModuleTopic6.Orders;
using System;
using Volo.Abp.Domain.Entities;

namespace ModuleTopic6.OrderLists
{
    public class OrderList: Entity<Guid>
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int OrderedQuantity { get; set; }
        public float PurchasePrice { get; set; }
        public float TotalMoney { get; set; }
    }
}
