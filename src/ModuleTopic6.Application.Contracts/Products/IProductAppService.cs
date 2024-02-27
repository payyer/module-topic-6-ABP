using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModuleTopic6.Products
{
    public interface IProductAppService: IApplicationService
    {
        Task<List<ProductDto>> GetProductListAsync();
        Task<ProductDto> GetProductByIdAsync(Guid productId);
        Task DeleteProductAsync(Guid productId);
        Task<ProductDto> UpdateProductAsync
            (
                Guid productId,
                string name,
                string productCode,
                float purchasePrice
            );
        Task<ProductDto> CreateProductAsync
            (
                string name,
                string productCode,
                float purchasePrice
            );
    }
}
