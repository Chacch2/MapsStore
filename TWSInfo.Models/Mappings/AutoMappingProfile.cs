using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.DTOs;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Models.Mappings
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile() 
        {
            CreateMap<Stores, StoreDto>().ReverseMap();
            CreateMap<Chains, ChainDto>().ReverseMap();
            CreateMap<StoreTypes, StoreTypeDto>().ReverseMap();

            // 將 StoreType 映射到 CategoryDto，並將 SubTypes 映射到 Children
            CreateMap<StoreTypes, CategoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StoreTypeId))
                .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.SubTypes));

            // 將 SubType 映射到 CategoryDto，並將 Chains 映射到 Children
            CreateMap<SubTypes, CategoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubTypeId))
                .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Chains));

            // 將 Chain 映射到 CategoryDto，並將 Stores 映射到 Children
            CreateMap<Chains, CategoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ChainId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.LogoUrl))
                .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Stores));

            // 將 Store 映射到 CategoryDto，這一層沒有子節點
            CreateMap<Stores, CategoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StoreId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Children, opt => opt.Ignore());

            CreateMap<SubTypes, SubTypeDto>().ReverseMap();
        }
    }
}
