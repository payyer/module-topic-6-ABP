using ModuleTopic6.OrderLists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;

namespace ModuleTopic6.Orders
{
    public class Order: Entity<Guid>
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderedDate { get; set; }
        public string Status { get; set; }
        public int TotalQuantity { get; set; }
        public float TotalMoney { get; set; }
        public ICollection<OrderList> OrderLists { get; set; }
        public Order() 
        {
            OrderLists = new Collection<OrderList>();
        }

    }
}
