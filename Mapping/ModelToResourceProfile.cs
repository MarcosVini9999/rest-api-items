using AutoMapper;
using rest_api_items.Domain.Models;
using rest_api_items.Resources;

namespace rest_api_items.Mapping
{
    public class ModelToResourceProfile : Profile
    {
            public ModelToResourceProfile()
            {
                CreateMap<Item, ItemResource>();
            }
    }
}