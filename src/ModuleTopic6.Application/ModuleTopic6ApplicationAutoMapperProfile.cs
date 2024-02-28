using AutoMapper;
using ModuleTopic6.OrderLists;
using ModuleTopic6.Orders;
using ModuleTopic6.Products;

namespace ModuleTopic6;

public class ModuleTopic6ApplicationAutoMapperProfile : Profile
{
    public ModuleTopic6ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        // Đăng ký Mpaer ở đâu
        CreateMap<Order, OrderDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<OrderList, OrderListDto>();
    }
}
