using AutoMapper;
using HexagonalSample.Application.DtoClasses.AppUserProfiles.Commands;
using HexagonalSample.Application.DtoClasses.AppUserProfiles.Queries;
using HexagonalSample.Application.DtoClasses.AppUsers.Commands;
using HexagonalSample.Application.DtoClasses.AppUsers.Queries;
using HexagonalSample.Application.DtoClasses.Categories.Commands;
using HexagonalSample.Application.DtoClasses.Categories.Queries;
using HexagonalSample.Application.DtoClasses.OrderDetails.Commands;
using HexagonalSample.Application.DtoClasses.OrderDetails.Queires;
using HexagonalSample.Application.DtoClasses.Orders.Commands;
using HexagonalSample.Application.DtoClasses.Orders.Queries;
using HexagonalSample.Application.DtoClasses.Products.Commands;
using HexagonalSample.Application.DtoClasses.Products.Queries;
using HexagonalSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateAppUserCommand, AppUser>();
            CreateMap<UpdateAppUserCommand, AppUser>();
            CreateMap<AppUser, GetAppUserQueryResult>();

            CreateMap<CreateAppUserProfileCommand, AppUserProfile>();
            CreateMap<UpdateAppUserProfileCommand, AppUserProfile>();
            CreateMap<AppUserProfile, GetAppUserProfileQueryResult>();

            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();
            CreateMap<Order, GetOrderQueryResult>();

            CreateMap<CreateOrderDetailCommand, OrderDetail>();
            CreateMap<UpdateOrderDetailCommand, OrderDetail>();
            CreateMap<OrderDetail, GetOrderDetailQueryResult>();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, GetProductQueryResult>();

            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, GetCategoryQueryResult>();
        }
    }
}
