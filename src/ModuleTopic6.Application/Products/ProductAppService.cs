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

        public async Task<ProductDto> CreateProductAsync
            (
                string name,
                string productCode, 
                float purchasePrice
            )
        {
            var product = await _productRepository.InsertAsync(new Product
            { 
                Name = name,
                ProductCode = productCode,
                PurchasePrice = purchasePrice
            });
            return new ProductDto
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                Name= product.Name,
                PurchasePrice = product.PurchasePrice
            };
        }



        public async Task DeleteProductAsync(Guid productId)
        {
            await _productRepository.DeleteAsync(productId);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid productId)
        {
            var product = await _productRepository.GetAsync(productId);
            return new ProductDto
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                PurchasePrice = product.PurchasePrice,
                Name = product.Name,
            };
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

        public async Task<ProductDto> UpdateProductAsync(
            Guid productId, 
            string name,
            string productCode,
            float purchasePrice
            )
        {

            var productToUpdate = await _productRepository.GetAsync(productId);
            productToUpdate.ProductCode = productCode;
            productToUpdate.Name = name;
            productToUpdate.PurchasePrice = purchasePrice;

            await _productRepository.UpdateAsync(productToUpdate);

            return new ProductDto
            {
                Id = productToUpdate.Id,
                Name = productToUpdate.Name,
                ProductCode = productToUpdate.ProductCode,
                PurchasePrice = productToUpdate.PurchasePrice
            };
        }
    }
}
