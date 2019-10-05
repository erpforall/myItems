using AutoMapper;
using MyItemApi.Data.Entities;
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

            CreateMap<ItemAttribute, ItemAttributeView>()
                .ReverseMap();

            CreateMap<Item, ItemView>()
                .ForMember(dest => dest.ItemTextViews, ex => ex.MapFrom(src => (src.ItemTexts)));

            CreateMap<ItemView, Item>()
                .ForMember(dest => dest.ItemTexts, ex => ex.MapFrom(src => (src.ItemTextViews)));

            CreateMap<Hierarchy, HierarchyView>()
                .ReverseMap();

            CreateMap<AttributeCategory, AttributeCategoryView>()
                .ForMember(dest => dest.AttributeNameViews, ex => ex.MapFrom(src => (src.AttributeNames)));

            CreateMap<AttributeCategoryView, AttributeCategory>()
                .ForMember(dest => dest.AttributeNames, ex => ex.MapFrom(src => (src.AttributeNameViews)));

            CreateMap<AttributeName, AttributeNameView>()
                .ForMember(dest => dest.AttributeValueViews, ex => ex.MapFrom(src => (src.AttributeValues)));

            CreateMap<AttributeNameView, AttributeName>()
                .ForMember(dest => dest.AttributeValues, ex => ex.MapFrom(src => (src.AttributeValueViews)));

            CreateMap<AttributeValue, ItemAttributeView>()
                .ForMember(dest => dest.AttributeValueId, ex => ex.MapFrom(src => (src.AttributeValueId)))
                .ForMember(dest => dest.AttributeValue, ex => ex.MapFrom(src => (src.Value)))
                .ForMember(dest => dest.AttributeNameId, ex => ex.MapFrom(src => (src.AttributeNameId)))
                .ForMember(dest => dest.AttributeName, ex => ex.MapFrom(src => (src.AttributeName.Name)));

            CreateMap<AttributeValue, AttributeValueView>()
                .ReverseMap();
        }
    }
}
