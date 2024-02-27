using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ModuleTopic6.Products
{
    public class ProductDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public float PurchasePrice { get; set; }
    }
}
