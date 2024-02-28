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
        IProductAppService _productAppService { get; set; }
        [Inject]
        IOrderAppService _orderAppService { get; set; }
        [Inject]
        IOrderListAppService _orderListAppService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string OrderId { get; set; }
        [Inject] 
        INotificationService NotificationService { get; set; }
        private Guid orderIdGuid;
        private Guid orderListGuidId;
        private List<string> status { get; set; } = new List<string> { "Khởi tạo", "Xác nhận", "Vận chuyển", "Hoàn thành", "Hủy" };

        public OrderDto InputOrderDto { get; set; } = new OrderDto();
        public OrderListDto InputOrderListDto { get; set; } = new OrderListDto();
        public ProductDto SelectedProductDto { get; set; } = new ProductDto();
        public List<ProductDto> ProductDtos { get; set; }
        public List<OrderListDto> orderListDtos { get; set; } = new List<OrderListDto>();
        public List<OrderListDto> OrderListToDelete { get; set; }
        public Validations validationsOrder { get; set; }
        public Validations validationsOrderList { get; set; }
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
            if (orderIdGuid != Guid.Empty)
            {
                InputOrderDto = await _orderAppService.GetOrderByIdAsync(orderIdGuid);
                orderListDtos = await _orderListAppService.GetOrderListsAsync(orderIdGuid);
            }
        }
        public async Task OnSelectedValueChanged(Guid productId)
        {
            InputOrderListDto.OrderedQuantity = 0;
            if (productId != Guid.Empty)
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
            if ( await validationsOrder.ValidateAll() && orderListDtos.Count != 0)
            {
                var order = await _orderAppService.CreateOrderAsync(orderDto: InputOrderDto);
                foreach (var orderList in orderListDtos)
                {
                    orderList.OrderId = order.Id;
                    await _orderListAppService.CreateOrderListAsync(orderList);
                }
                _navigationManager.NavigateTo("/orders");
            }
            else
            {
                Console.WriteLine("Không có sản phẩm xin hảy thêm");
            }
        }
        // Xử lý ở đây
        private async Task AddProductToOrderList(Guid productId)
        {
            if(await validationsOrderList.ValidateAll() )
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
                orderListDtos.Add(newOrderList);
                int totalQuantity = 0;
                float totalMoney = 0;
                foreach (var orderList in orderListDtos)
                {
                    totalQuantity += orderList.OrderedQuantity;
                    totalMoney += orderList.TotalMoney;
                }
                InputOrderDto.TotalMoney = totalMoney;
                InputOrderDto.TotalQuantity = totalQuantity;
                HideModal();
            }
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
        private async Task HideModal()
        {
            modalVisible = false;
            isUPdateOrderLIst = false;
            SelectedProductDto = new ProductDto();
            InputOrderListDto = new OrderListDto();
            await validationsOrderList.ClearAll();
        }
        private Task OnModalClosing(ModalClosingEventArgs e)
        {
           return HideModal();
        }

        private async Task UpdateOrder(Guid orderId)
        {
            var order = await _orderAppService.UpdateOrderByIdAsync(orderIdGuid, InputOrderDto);

            foreach (var orderList in orderListDtos)
            {
                if (orderList.Id == Guid.Empty)
                {
                    orderList.OrderId = order.Id;
                    await _orderListAppService.CreateOrderListAsync(orderList);
                }
            }
            foreach (var oderListDelete in OrderListToDelete)
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
            InputOrderDto.TotalMoney = totalMoney;
            InputOrderDto.TotalQuantity = totalQuantity;
        }

        private async Task ShowUpdateOrderList(OrderListDto orderListDto)
        {
            if (orderListDto.Id == Guid.Empty)
            {
                InputOrderListDto = orderListDto;
            }
            else
            {
                InputOrderListDto = await _orderListAppService.GetOrderListByIdAsync(orderListDto.Id);
                InputOrderListDto.Name = orderListDto.Name;
            }
            isUPdateOrderLIst = true;
            orderListGuidId = orderListDto.Id;
            ShowModal();
        }


        private async Task UpdateOrderList()
        {
            if ( await validationsOrderList.ValidateAll())
            {
                if (orderListGuidId == Guid.Empty)
                {
                    var index = orderListDtos.FindIndex(o => o == InputOrderListDto);
                    orderListDtos[index] = InputOrderListDto;
                }
                else
                {
                    var orderListUpdate = await _orderListAppService.UpdateOrderListAsync(orderListGuidId, InputOrderListDto);
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

        static void IsValidInteger(ValidatorEventArgs e)
        {
            if (Blazorise.Utilities.Converters.TryChangeType<int>(e.Value, out var result))
            {
                if (result > 0)
                {
                    e.Status = ValidationStatus.Success;
                    return;
                }
            }

            e.Status = ValidationStatus.Error;
        }

        static void IsValidFloat(ValidatorEventArgs e)
        {
            if (Blazorise.Utilities.Converters.TryChangeType<float>(e.Value, out var result))
            {
                if (result > 0)
                {
                    e.Status = ValidationStatus.Success;
                    return;
                }
            }

            e.Status = ValidationStatus.Error;
        }

        void ValidateStringSelect(ValidatorEventArgs e)
        {
            var selectedValue = e.Value as string;
            e.Status = !string.IsNullOrEmpty(selectedValue) ? ValidationStatus.Success : ValidationStatus.Error;
        }

        void ValidateGuidSelect(ValidatorEventArgs e)
        {
            var selectedValue = (Guid)e.Value;
            e.Status = selectedValue != Guid.Empty ? ValidationStatus.Success : ValidationStatus.Error;
        }
    }
}
