using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace ModuleTopic6.Products;

[Area(ModuleTopic6RemoteServiceConsts.ModuleName)]
[RemoteService(Name = ModuleTopic6RemoteServiceConsts.RemoteServiceName)]
[Route("api/ModuleTopic6/product")]
public class ProductController: ModuleTopic6Controller , IProductAppService
{
    private readonly IProductAppService _productAppService;
    public ProductController(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    [Route("create")]
    [HttpPost]
    public async Task<ProductDto> CreateProductAsync(string name, string productCode, float purchasePrice)
    {
        return await _productAppService.CreateProductAsync(name, productCode, purchasePrice);
    }


    [Route("delete/{productId}")]
    [HttpDelete]
    public async Task DeleteProductAsync(Guid productId)
    {
        await _productAppService.DeleteProductAsync(productId);
    }
    [Route("{productId}")]
    [HttpGet]
    public Task<ProductDto> GetProductByIdAsync(Guid productId)
    {
        return _productAppService.GetProductByIdAsync(productId);
    }

    [HttpGet]
    public async Task<List<ProductDto>> GetProductListAsync()
    {
        return await _productAppService.GetProductListAsync();
    }
    [Route("update/{productId}")]
    [HttpPut]
    public async Task<ProductDto> UpdateProductAsync(Guid productId, string name, string productCode, float purchasePrice)
    {
        return await _productAppService.UpdateProductAsync(productId, name, productCode, purchasePrice);
    }
}

