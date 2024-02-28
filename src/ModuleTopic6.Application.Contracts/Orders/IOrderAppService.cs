using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModuleTopic6.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task<List<OrderDto>> GetListOrderAsync();
        Task<OrderDto> GetOrderByIdAsync(Guid orderId);
        //Task<OrderDto> CreateOrderAsync
        //    (
        //        string userName,
        //        string phoneNumber,
        //        string address,
        //        string status,
        //        int totalQuantity,
        //        float totalMoney
        //    );

        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        Task<OrderDto> UpdateOrderByIdAsync(Guid orderId,OrderDto orderDto);
        Task DeleteOrderByIdAsync(Guid orderId );
    }
}
