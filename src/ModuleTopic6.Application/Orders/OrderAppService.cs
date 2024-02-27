using ModuleTopic6.OrderLists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<OrderDto> CreateOrderAsync(string userName, string phoneNumber, string address, string status,  int totalQuantity, float totalMoney)
        {
            var order = new Order
            {
                UserName = userName,
                PhoneNumber = phoneNumber,
                Address = address,
                OrderedDate = DateTime.Now,
                Status = status,
                TotalQuantity = totalQuantity,
                TotalMoney = totalMoney,
            };
            order.OrderLists = new Collection<OrderList>();
            order = await _orderAppService.InsertAsync(order);
            return new OrderDto { 
                Id = order.Id ,
                Address = order.Address,
                OrderedDate =order.OrderedDate,
                PhoneNumber = order.PhoneNumber,
                Status = order.Status,
                UserName = order.UserName,
                TotalQuantity = order.TotalQuantity,
                TotalMoney = order.TotalMoney,
            };
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
            return new OrderDto
            {
                Id = order.Id,
                OrderedDate = order.OrderedDate,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                UserName = order.UserName,
                Status = order.Status,
                TotalMoney= order.TotalMoney,
                TotalQuantity= order.TotalQuantity,
            };
        }

        
        public async Task<OrderDto> UpdateOrderByIdAsync(Guid orderId, string userName, string phoneNumber, string address, DateTime orderedDate, string status,  int totalQuantity,  float totalMoney)
        {
            var order = await _orderAppService.GetAsync(orderId);

            order.UserName = userName;
            order.PhoneNumber = phoneNumber;
            order.Address = address;
            order.OrderedDate = orderedDate;
            order.Status = status;
            order.TotalQuantity = totalQuantity;
            order.TotalMoney = totalMoney;

            await _orderAppService.UpdateAsync(order);

            return new OrderDto
            {
                Id = order.Id,
                UserName = order.UserName,
                PhoneNumber = order.PhoneNumber,
                Address = order.Address,
                OrderedDate = order.OrderedDate,
                Status = order.Status,
                TotalQuantity = order.TotalQuantity,
                TotalMoney = order.TotalMoney
            };
        }
    }
}
