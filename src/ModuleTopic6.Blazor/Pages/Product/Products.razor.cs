using Blazorise;
using Microsoft.AspNetCore.Components;
using ModuleTopic6.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModuleTopic6.Blazor.Pages.Product
{
    public partial class Products
    {
        // Client
        private Guid ProductId {  get; set; }
        private bool modalVisible;
        private bool modalDelete;
        private bool isUpdate { get; set; } = false;
        private Task ShowModalDelete(Guid productid)
        {
            modalDelete = true;
            ProductId = productid;
            return Task.CompletedTask;
        }
        private Task HideModalDelete()
        {
            return Task.CompletedTask;
        }
        private async Task ShowModalUpdate(Guid productId)
        {
            isUpdate = true;
            modalVisible = true;
            InputProductDto = await ProductAppService.GetProductByIdAsync(productId);
        }
        private Task ShowModal()
        {
            isUpdate = false;
            modalDelete = false;
            modalVisible = true;
            return Task.CompletedTask;
        }

        private Task HideModal()
        {
            modalVisible = false;
            InputProductDto = new ProductDto();
            return Task.CompletedTask;
        }
        private Task OnModalClosing(ModalClosingEventArgs e)
        {
            HideModal();
            return Task.CompletedTask;
        }
        // API
        [Inject] IProductAppService ProductAppService { get; set; }

        private List<ProductDto> productDtos { get; set; }
        private ProductDto InputProductDto { get; set; } = new ProductDto();

        protected override async Task OnInitializedAsync()
        {
            productDtos = await ProductAppService.GetProductListAsync();
        }

        public async Task CreateProduct()
        {
            await ProductAppService.CreateProductAsync(
                    InputProductDto.Name,
                    InputProductDto.ProductCode,
                    InputProductDto.PurchasePrice
                );
            InputProductDto = new ProductDto();
            productDtos = await ProductAppService.GetProductListAsync();
            HideModal();
        }
        public async Task UpdateProduct( ProductDto product )
        {
            await ProductAppService.UpdateProductAsync(
                    product.Id,
                    product.Name,
                    product.ProductCode,
                    product.PurchasePrice
                );
            productDtos = await ProductAppService.GetProductListAsync();
            HideModal();
        }
        public async Task DeleteProduct(Guid productId)
        {
            await ProductAppService.DeleteProductAsync(productId);
            productDtos = await ProductAppService.GetProductListAsync();
            HideModalDelete();
        }
    }
}
