using System;
using Volo.Abp.Application.Dtos;

namespace ModuleTopic6.Orders
{
    public class OrderDto : EntityDto<Guid>
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderedDate { get; set; }
        public string Status { get; set; }
        public int TotalQuantity { get; set; }
        public float TotalMoney { get; set; }
    }
}
