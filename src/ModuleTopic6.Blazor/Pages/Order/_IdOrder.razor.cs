using Blazorise;
using Microsoft.AspNetCore.Components;
using ModuleTopic6.OrderLists;
using ModuleTopic6.Orders;
using ModuleTopic6.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModuleTopic6.Blazor.Pages.Order
{
    public partial class _IdOrder
    {
        [Inject]
        IProductAppService _productAppService {  get; set; }
        [Inject]
        IOrderAppService _orderAppService { get; set; }
        [Inject]
        IOrderListAppService _orderListAppService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string OrderId { get; set; }
        private Guid orderIdGuid;
        private Guid orderListGuidId;
        private List<string> status { get; set; } = new List<string> { "Khởi tạo", "Xác nhận", "Vận chuyển", "Hoàn thành", "Hủy" };

        public OrderDto InputOrderDto { get; set; } = new OrderDto();
        public OrderListDto InputOrderListDto { get; set; } = new OrderListDto();
        public ProductDto SelectedProductDto { get; set; } = new ProductDto();
        public List<ProductDto> ProductDtos { get; set; }
        public List<OrderListDto> orderListDtos { get; set; } = new List<OrderListDto>();
        public List<OrderListDto> OrderListToDelete { get; set; }
        private bool modalVisible;
        public Guid defaultValue { get; set; } = Guid.Empty;
        public Guid SelectedProductId { get; set; }
        public int totalQuanitty;
        public bool isUPdateOrderLIst = false;
        protected override async Task OnInitializedAsync()
        {
            ProductDtos = await _productAppService.GetProductListAsync();
            OrderListToDelete = new List<OrderListDto>();
            InputOrderDto.OrderedDate = DateTime.Now;
            if (Guid.TryParse(OrderId, out Guid result))
            {
                orderIdGuid = result;
            }
            if(orderIdGuid != Guid.Empty)
            {
                InputOrderDto = await _orderAppService.GetOrderByIdAsync(orderIdGuid);
                orderListDtos = await _orderListAppService.GetOrderListsAsync(orderIdGuid);
            }
        }
        public async Task OnSelectedValueChanged(Guid productId)
        {
            if(productId != Guid.Empty)
            {
                SelectedProductDto = await _productAppService.GetProductByIdAsync(productId);
                InputOrderListDto.Name = SelectedProductDto.Name;
                InputOrderListDto.ProductCode = SelectedProductDto.ProductCode;
                InputOrderListDto.ProductId = SelectedProductDto.Id;
                InputOrderListDto.PurchasePrice = SelectedProductDto.PurchasePrice;
                SelectedProductId = SelectedProductDto.Id;
            }
            else
            {
                SelectedProductDto = new ProductDto();
                InputOrderListDto = new OrderListDto();
            }
        }
        private async Task CraeteOrder()
        {
            var order = await _orderAppService.CreateOrderAsync(
                    userName: InputOrderDto.UserName,
                    phoneNumber: InputOrderDto.PhoneNumber,
                    address: InputOrderDto.Address,
                    status: InputOrderDto.Status,
                    totalQuantity: InputOrderDto.TotalQuantity,
                    totalMoney: InputOrderDto.TotalMoney
                );
            foreach (var orderList in orderListDtos)
            {
                await _orderListAppService.CreateOrderListAsync(
                        orderId: order.Id,
                        orderList.ProductId,
                        orderList.Name,
                        orderList.ProductCode,
                        orderList.OrderedQuantity,
                        orderList.PurchasePrice,
                        orderList.TotalMoney
                    );
            }
            _navigationManager.NavigateTo("/orders");
        }
        private async Task AddProductToOrderList(Guid productId)
        {
            var newOrderList = new OrderListDto
            {
                OrderId = Guid.Empty,
                ProductId = productId,
                Name = InputOrderListDto.Name,
                ProductCode = InputOrderListDto.ProductCode,
                OrderedQuantity = InputOrderListDto.OrderedQuantity,
                PurchasePrice = InputOrderListDto.PurchasePrice,
                TotalMoney = InputOrderListDto.TotalMoney,
            };
            orderListDtos.Add( newOrderList );
            int totalQuantity = 0;
            foreach (var orderList in orderListDtos)
            {
                totalQuantity += orderList.OrderedQuantity;
                InputOrderDto.TotalMoney += orderList.TotalMoney;
            }
            InputOrderDto.TotalQuantity = totalQuantity;
            HideModal();
        }
        private void UpdateQuantity(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int parsedValue))
            {
                InputOrderListDto.TotalMoney = parsedValue * InputOrderListDto.PurchasePrice;
                InputOrderListDto.OrderedQuantity = parsedValue;
            }
        }
        private Task ShowModal()
        {
            modalVisible = true;

            return Task.CompletedTask;
        }
        private Task HideModal()
        {
            modalVisible = false;
            SelectedProductDto = new ProductDto();
            InputOrderListDto = new OrderListDto();
            return Task.CompletedTask;
        }
        private Task OnModalClosing(ModalClosingEventArgs e)
        {
             return HideModal();
        }

        private async Task UpdateOrder(Guid orderId)
        {
            await _orderAppService.UpdateOrderByIdAsync(
                orderIdGuid,
                InputOrderDto.UserName,
                InputOrderDto.PhoneNumber,
                InputOrderDto.Address,
                InputOrderDto.OrderedDate,
                InputOrderDto.Status,
                InputOrderDto.TotalQuantity,
                InputOrderDto.TotalMoney
            );

            foreach (var orderList in orderListDtos)
            {
                if( orderList.Id == Guid.Empty)
                {
                    await _orderListAppService.CreateOrderListAsync(
                            orderIdGuid,
                            orderList.ProductId,
                            orderList.Name,
                            orderList.ProductCode,
                            orderList.OrderedQuantity,
                            orderList.PurchasePrice,
                            orderList.TotalMoney
                        );
                }
            }
            foreach( var oderListDelete in OrderListToDelete)
            {
                await _orderListAppService.DeleteOrderListById(oderListDelete.Id);
            }
            _navigationManager.NavigateTo("/orders");
        }


        private async Task SaveOrderListNeedDelete(OrderListDto orderList)
        {
            orderListDtos.Remove(orderList);
            OrderListToDelete.Add(orderList);
            int totalQuantity = 0;
            float totalMoney = 0;
            foreach (var orderListCalculate in orderListDtos)
            {
                totalQuantity += orderListCalculate.OrderedQuantity;
                totalMoney += orderListCalculate.TotalMoney;
            }
            InputOrderDto.TotalMoney = totalQuantity;
            InputOrderDto.TotalQuantity = totalQuantity;
        }

        private async Task ShowUpdateOrderList(Guid orderListId)
        {
            InputOrderListDto = await _orderListAppService.GetOrderListByIdAsync(orderListId);
            isUPdateOrderLIst = true;
            orderListGuidId = orderListId;
            ShowModal();
        }

        private async Task UpdateOrderList()
        {
            var orderListUpdate = await _orderListAppService.UpdateOrderListAsync(
                    orderListGuidId,
                    InputOrderListDto.OrderId,
                    InputOrderListDto.ProductId,
                    InputOrderListDto.Name,
                    InputOrderListDto.ProductCode,
                    InputOrderListDto.OrderedQuantity,
                    InputOrderListDto.PurchasePrice,
                    InputOrderListDto.TotalMoney
                );
            var updatedOrderList = orderListDtos.Find(o => o.Id == orderListGuidId);
            if (updatedOrderList != null)
            {
                updatedOrderList.OrderId = orderListUpdate.OrderId;
                updatedOrderList.ProductId = orderListUpdate.ProductId;
                updatedOrderList.Name = orderListUpdate.Name;
                updatedOrderList.ProductCode = orderListUpdate.ProductCode;
                updatedOrderList.OrderedQuantity = orderListUpdate.OrderedQuantity;
                updatedOrderList.PurchasePrice = orderListUpdate.PurchasePrice;
                updatedOrderList.TotalMoney = orderListUpdate.TotalMoney;
            }

            int totalQuantity = 0;
            float totalMoney = 0;
            foreach (var orderListCalculate in orderListDtos)
            {
                totalQuantity += orderListCalculate.OrderedQuantity;
                totalMoney += orderListCalculate.TotalMoney;
            }
            InputOrderDto.TotalMoney = totalMoney;
            InputOrderDto.TotalQuantity = totalQuantity;

            HideModal();
        }
    }
}
