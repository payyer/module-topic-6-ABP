using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ModuleTopic6.Orders
{
    [Dependency(ReplaceServices = true)]
    [RemoteService]
    public class OrderAppService : ModuleTopic6AppService, IOrderAppService
    {
        private readonly IRepository<Order,Guid> _orderAppService;
        public OrderAppService(IRepository<Order, Guid> orderAppService)
        {
            _orderAppService = orderAppService;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            var newOrder = new Order
            {
                UserName = orderDto.UserName,
                PhoneNumber = orderDto.PhoneNumber,
                Address = orderDto.Address,
                OrderedDate = DateTime.Now,
                Status = orderDto.Status,
                TotalQuantity = orderDto.TotalQuantity,
                TotalMoney = orderDto.TotalMoney,
            };
            await _orderAppService.InsertAsync(newOrder);
            OrderDto result = ObjectMapper.Map<Order, OrderDto>(newOrder);
            return result;
        }

        public async Task DeleteOrderByIdAsync(Guid orderId)
        {
            await _orderAppService.DeleteAsync(orderId);
        }

        public async Task<List<OrderDto>> GetListOrderAsync()
        {
            var orders = await _orderAppService.GetListAsync();

            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                OrderedDate = o.OrderedDate,
                Address = o.Address,
                PhoneNumber = o.PhoneNumber,
                Status = o.Status,
                UserName = o.UserName,
                TotalQuantity = o.TotalQuantity,
                TotalMoney = o.TotalMoney,
            }).ToList();
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _orderAppService.GetAsync(orderId);
            var orderDto = ObjectMapper.Map<Order, OrderDto>(order);
            return orderDto;
        }

        
        public async Task<OrderDto> UpdateOrderByIdAsync(Guid orderId,OrderDto orderDto)
        {
            var order = await _orderAppService.GetAsync(orderId);
            
            order.UserName = orderDto.UserName;
            order.PhoneNumber = orderDto.PhoneNumber;
            order.Address = orderDto.Address;
            order.OrderedDate = orderDto.OrderedDate;
            order.Status = orderDto.Status;
            order.TotalQuantity = orderDto.TotalQuantity;
            order.TotalMoney = orderDto.TotalMoney;
            await _orderAppService.UpdateAsync(order);

            var result = ObjectMapper.Map<Order, OrderDto>(order);
            return result;
        }
    }
}
