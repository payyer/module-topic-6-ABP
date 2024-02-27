using Microsoft.AspNetCore.Components;
using ModuleTopic6.OrderLists;
using ModuleTopic6.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModuleTopic6.Blazor.Pages.Order
{
    public partial class Orders
    {
        [Inject]
        IOrderAppService OrderAppService { get; set; }
        [Inject]
        IOrderListAppService OrderListAppService { get; set; }
        [Inject] 
        NavigationManager NavigationManager { get; set; }
        public List<OrderDto> orderDtos { get; set; }
        public OrderDto InputOrderDto {get; set;} = new OrderDto();
        private bool modalDelete;
        private Guid orderToDelete;

        protected override async Task OnInitializedAsync()
        {
            orderDtos = await OrderAppService.GetListOrderAsync();
        }

        public void NavCreateOrder()
        {
            NavigationManager.NavigateTo($"/orders/detail/{Guid.Empty}");
        }

        public void NavDetailOrder(Guid orderId)
        {
            string OrderId = orderId.ToString();
            NavigationManager.NavigateTo($"/orders/detail/{OrderId}");
        }

        private Task ShowModalDelete(Guid orderId)
        {
            orderToDelete = orderId;
            modalDelete = true;

            return Task.CompletedTask;
        }

        private Task HideModalDelete()
        {
            modalDelete = false;
            return Task.CompletedTask;
        }

        private async Task DeleteOrder(Guid orderId)
        {
            await OrderAppService.DeleteOrderByIdAsync(orderId);
            var orderLists = await OrderListAppService.GetOrderListsAsync(orderId);
            foreach (var order in orderLists)
            {
                await OrderListAppService.DeleteOrderList(orderId);
            }
            orderDtos = await OrderAppService.GetListOrderAsync();
            HideModalDelete();
        }
    }
}
