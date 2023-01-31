using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using rest_api_items.Domain.Models;
using rest_api_items.Extensions;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveItemResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var items = _mapper.Map<SaveItemResource, Item>(resource);
            var result = await _itemService.SaveAsync(items);

            if (!result.Success) return BadRequest(result.Message);

            var itemResource = _mapper.Map<Item, ItemResource>(result.Item);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveItemResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var items = _mapper.Map<SaveItemResource, Item>(resource);
            var result = await _itemService.UpdateAsync(id, items);

            if (!result.Success) return BadRequest(result.Message);

            var itemResource = _mapper.Map<Item, ItemResource>(result.Item);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _itemService.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Message);

            var itemResource = _mapper.Map<Item, ItemResource>(result.Item);
            return Ok(itemResource);
        }
    }
}