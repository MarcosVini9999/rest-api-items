using AutoMapper;
using rest_api_items.Domain.Models;
using rest_api_items.Resources;

namespace rest_api_items.Extensions
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveItemResource, Item>();
        }
    }
}