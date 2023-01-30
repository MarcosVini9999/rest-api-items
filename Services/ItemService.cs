using rest_api_items.Domain.Models;
using rest_api_items.Domain.Repositories.IRepositories;
using rest_api_items.Services.IServices;

namespace rest_api_items.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> ListAsync()
        {
            return await _itemRepository.ListAsync();
        }
    }
}