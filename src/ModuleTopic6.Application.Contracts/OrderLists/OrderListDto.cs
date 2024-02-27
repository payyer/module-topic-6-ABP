using System;
using Volo.Abp.Application.Dtos;

namespace ModuleTopic6.OrderLists
{
    public class OrderListDto : EntityDto<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int OrderedQuantity { get; set; }
        public float PurchasePrice { get; set; }
        public float TotalMoney { get; set; }
    }
}
