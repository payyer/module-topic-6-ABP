using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ModuleTopic6.Products
{
    [Dependency(ReplaceServices = true)]
    [RemoteService]
    public class ProductAppService: ModuleTopic6AppService, IProductAppService
    {
        public readonly IRepository<Product, Guid> _productRepository;
        public ProductAppService(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> CreateProductAsync( ProductDto productDto )
        {
            var product = await _productRepository.InsertAsync(new Product
            { 
                Name = productDto.Name,
                ProductCode = productDto.ProductCode,
                PurchasePrice = productDto.PurchasePrice
            });
            var result = ObjectMapper.Map<Product, ProductDto>(product);
            return result;
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            await _productRepository.DeleteAsync(productId);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid productId)
        {
            var product = await _productRepository.GetAsync(productId);
            var result = ObjectMapper.Map<Product, ProductDto>(product);
            return result;
        }

        public async Task<List<ProductDto>> GetProductListAsync()
        {
            var products = await _productRepository.GetListAsync();
            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                ProductCode = x.ProductCode,
                Name = x.Name,
                PurchasePrice = x.PurchasePrice
            }
            ).ToList();
        }

        public async Task<ProductDto> UpdateProductAsync( Guid productId, ProductDto productDto )
        {
            var productToUpdate = await _productRepository.GetAsync(productId);

            productToUpdate.Name = productDto.Name;
            productToUpdate.ProductCode = productDto.ProductCode;
            productToUpdate.PurchasePrice = productDto.PurchasePrice;

            var updateProduct =  await _productRepository.UpdateAsync(productToUpdate);
            var result = ObjectMapper.Map<Product, ProductDto>(updateProduct);
            return result;
        }
    }
}
