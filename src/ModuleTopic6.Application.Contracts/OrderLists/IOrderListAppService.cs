using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
namespace ModuleTopic6.OrderLists
{
    public interface IOrderListAppService : IApplicationService
    {
        Task<OrderListDto> CreateOrderListAsync( OrderListDto orderListDto );
        Task<OrderListDto> UpdateOrderListAsync( Guid orderListId, OrderListDto orderListDto );
        Task<List<OrderListDto>> GetOrderListsAsync(Guid orderId);
        Task<OrderListDto> GetOrderListByIdAsync(Guid orderListId);
        Task DeleteOrderList(Guid orderId);
        Task DeleteOrderListById(Guid orderListId);
    }
}
