using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
namespace ModuleTopic6.OrderLists
{
    public interface IOrderListAppService : IApplicationService
    {
        Task<OrderListDto> CreateOrderListAsync(
                Guid orderId, 
                Guid productId,
                string name,
                string productCode,
                int orderedQuantity,
                float purchasePrice,
                float totalMoney
            );
        Task<OrderListDto> UpdateOrderListAsync(
                Guid orderListId,
                Guid orderId,
                Guid productId,
                string name,
                string productCode,
                int orderedQuantity,
                float purchasePrice,
                float totalMoney
            );
        Task<List<OrderListDto>> GetOrderListsAsync(Guid orderId);
        Task<OrderListDto> GetOrderListByIdAsync(Guid orderListId);
        Task DeleteOrderList(Guid orderId);
        Task DeleteOrderListById(Guid orderListId);
    }
}
