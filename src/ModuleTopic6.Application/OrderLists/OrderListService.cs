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



        public async Task<OrderListDto> CreateOrderListAsync(Guid orderId, Guid productId, string name, string productCode, int orderedQuantity, float purchasePrice, float totalMoney)
        {
            var orderList = await _orderListRepository.InsertAsync(new OrderList {
                OrderId = orderId,
                ProductId = productId,
                Name = name,
                OrderedQuantity = orderedQuantity,
                ProductCode = productCode,
                PurchasePrice = purchasePrice,
                TotalMoney = totalMoney,
            });

            return new OrderListDto
            {
                Id = orderList.Id,
                ProductId = orderList.ProductId,
                OrderedQuantity = orderList.OrderedQuantity,
                ProductCode = orderList.ProductCode,
                TotalMoney= orderList.TotalMoney,
                Name= name,
                OrderId = orderList.OrderId,
                PurchasePrice= orderList.PurchasePrice,
            };
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
            return new OrderListDto
            {
                Id = orderListId,
                ProductId = orderList.ProductId,
                OrderedQuantity = orderList.OrderedQuantity,
                ProductCode = orderList.ProductCode,
                TotalMoney= orderList.TotalMoney,
                OrderId= orderList.OrderId,
                PurchasePrice = orderList.PurchasePrice,
                Name = orderList.Name,
            };
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

        public async Task<OrderListDto> UpdateOrderListAsync(Guid orderListId, Guid orderId, Guid productId, string name, string productCode,  int orderedQuantity, float purchasePrice, float totalMoney)
        {
            var orderList = await _orderListRepository.GetAsync(orderListId);

            orderList.OrderId = orderId;
            orderList.ProductId = productId;
            orderList.Name = name;
            orderList.ProductCode = productCode;
            orderList.OrderedQuantity = orderedQuantity;
            orderList.PurchasePrice = purchasePrice;
            orderList.TotalMoney = totalMoney;

            await _orderListRepository.UpdateAsync(orderList);

            return new OrderListDto
            {
                Id = orderList.Id,
                OrderId = orderList.OrderId,
                ProductId = orderList.ProductId,
                Name = orderList.Name,
                ProductCode = orderList.ProductCode,
                OrderedQuantity = orderList.OrderedQuantity,
                PurchasePrice = orderList.PurchasePrice,
                TotalMoney = orderList.TotalMoney
            };
        }
    }
}
