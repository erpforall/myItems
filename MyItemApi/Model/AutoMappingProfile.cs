using AutoMapper;
using MyNoteApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Model
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {

            CreateMap<ItemText, ItemTextView>()
                .ReverseMap();

            CreateMap<ItemData, ItemDataView>()
                .ReverseMap();

            CreateMap<Item, ItemView>()
                .ReverseMap();

            CreateMap<Hierarchy, HierarchyView>()
                .ReverseMap();
        }
    }
}
