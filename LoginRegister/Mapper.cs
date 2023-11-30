using AutoMapper;
using DTO;
using Entities;

namespace MySite
{
    public class Mapper:Profile
    {
      
        public Mapper()
        {
           
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemsDTO>().ReverseMap();

        }




    }
}
