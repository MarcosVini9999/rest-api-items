using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using rest_api_items.Domain.Models;
using rest_api_items.Resources;
using rest_api_items.Services.IServices;

namespace rest_api_items.Controllers
{
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
             _itemService = itemService;
             _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemResource>> GetAllAsync()
        {
            var items = await _itemService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Item>,IEnumerable<ItemResource>>(items);

            return resources;
        }
    }
}