using AutoMapper;
using System;
using System.Collections.Generic;
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
        }
    }
}
