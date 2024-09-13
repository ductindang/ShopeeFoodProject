using AutoMapper;
using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using DataAccessLayer.Models;
using System;

namespace BusinessLogicLayer.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId))
                .ForMember(dest => dest.DiscountId, opt => opt.MapFrom(src => src.DiscountId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
            CreateMap<Category, CategoryRequest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForSourceMember(src => src.CreatedAt, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.UpdatedAt, opt => opt.DoNotValidate())
                .ReverseMap();
            CreateMap<SubCategory, SubCategoryRequest>().ReverseMap();
            CreateMap<Store, StoreRequest>().ReverseMap();
            CreateMap<StoreAddress, StoreAddressRequest>().ReverseMap();
            CreateMap<UserAddress, UserAddressRequest>().ReverseMap();
            CreateMap<BaseUserAddress, UserAddress>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Ward, WardRequest>().ReverseMap();
            CreateMap<Province, ProvinceRequest>().ReverseMap();
            CreateMap<District, DistrictRequest>().ReverseMap();
            CreateMap<Discount, DiscountRequest>().ReverseMap();



            CreateMap<Category, BaseCategory>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<SubCategory, BaseSubCategory>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ReverseMap();
            CreateMap<Product, BaseProduct>()
                .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId))
                .ForMember(dest => dest.DiscountId, opt => opt.MapFrom(src => src.DiscountId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();

            CreateMap<ProductDetail, ProductDetailDto>().ReverseMap();
            

            CreateMap<BaseDiscount, Discount>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<StoreDetail, StoreDetailDto>().ReverseMap();
            CreateMap<Menu, MenuRequest>().ReverseMap();
            CreateMap<MenuProduct, MenuProductDto>().ReverseMap();
            CreateMap<StoreMenuProductDetail, StoreMenuProductDetailDto>().ReverseMap();
            CreateMap<UserAddressDetail, UserAddressDetailDto>().ReverseMap();


            CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<BaseOrder, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<OrderDetail, OrderDetailRequest>().ReverseMap();
            CreateMap<BaseOrderDetail, OrderDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
