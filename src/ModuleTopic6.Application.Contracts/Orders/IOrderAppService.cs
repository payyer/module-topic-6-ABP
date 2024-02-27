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
        Task<OrderDto> CreateOrderAsync
            (
                string userName,
                string phoneNumber,
                string address,
                string status,
                int totalQuantity,
                float totalMoney
            );
        Task<OrderDto> UpdateOrderByIdAsync
            (
                Guid orderId,
                string userName,
                string phoneNumber,
                string address,
                DateTime orderedDate,
                string status,
                int totalQuanitty,
                float totalMoney
            );
        Task DeleteOrderByIdAsync(Guid orderId );
    }
}
