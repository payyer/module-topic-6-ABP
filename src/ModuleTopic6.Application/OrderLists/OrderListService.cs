using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ModuleTopic6.OrderLists
{
    [Dependency(ReplaceServices = true)]
    [RemoteService]
    public class OrderListService : ModuleTopic6AppService, IOrderListAppService
    {
        private readonly IRepository<OrderList, Guid> _orderListRepository;
        public OrderListService(IRepository<OrderList, Guid> orderListRepository)
        {
            _orderListRepository = orderListRepository;
        }



        public async Task<OrderListDto> CreateOrderListAsync( OrderListDto orderListDto )
        {
            var orderList = await _orderListRepository.InsertAsync(new OrderList {
                OrderId = orderListDto.OrderId,
                ProductId = orderListDto.ProductId,
                Name = orderListDto.Name,
                OrderedQuantity = orderListDto.OrderedQuantity,
                ProductCode = orderListDto.ProductCode,
                PurchasePrice = orderListDto.PurchasePrice,
                TotalMoney = orderListDto.TotalMoney,
            });
            var result = ObjectMapper.Map<OrderList, OrderListDto>(orderList);
            return result;
        }

        public async Task DeleteOrderList(Guid orderId)
        {
            await _orderListRepository.DeleteAsync(o => o.OrderId == orderId);
        }

        public async Task DeleteOrderListById(Guid orderListId)
        {
            await _orderListRepository.DeleteAsync(orderListId);
        }

        public async Task<OrderListDto> GetOrderListByIdAsync(Guid orderListId)
        {
            var orderList = await _orderListRepository.GetAsync(orderListId);
            var result = ObjectMapper.Map<OrderList, OrderListDto>(orderList);
            return result;
        }

        public async Task<List<OrderListDto>> GetOrderListsAsync(Guid orderId)
        {
            var orderLists = await _orderListRepository.GetListAsync();
            orderLists = orderLists.Where(o => o.OrderId == orderId).ToList();
            return orderLists.Select(ol => new OrderListDto
            {
                Id = ol.Id,
                ProductId = ol.ProductId,
                OrderId=ol.OrderId,
                OrderedQuantity=ol.OrderedQuantity,
                ProductCode = ol.ProductCode,
                TotalMoney=ol.TotalMoney,
                PurchasePrice = ol.PurchasePrice,
                Name = ol.Name,
            }).ToList();
        }

        public async Task<OrderListDto> UpdateOrderListAsync( Guid orderListId, OrderListDto orderListDto )
        {
            var getOrderList = await _orderListRepository.GetAsync(orderListId);
            getOrderList.Name = orderListDto.Name;
            getOrderList.ProductCode = orderListDto.ProductCode;
            getOrderList.OrderedQuantity = orderListDto.OrderedQuantity;
            getOrderList.PurchasePrice = orderListDto.PurchasePrice;
            getOrderList.TotalMoney = orderListDto.TotalMoney;
            var orderUpdate = await _orderListRepository.UpdateAsync(getOrderList);
            var result = ObjectMapper.Map<OrderList, OrderListDto>(orderUpdate);
            return result;
        }
    }
}
