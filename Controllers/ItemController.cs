using Microsoft.AspNetCore.Mvc;
using rest_api_items.Domain.Models;
using rest_api_items.Services.IServices;

namespace rest_api_items.Controllers
{
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
             _itemService = itemService;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await _itemService.ListAsync();

            return items;
        }
    }
}