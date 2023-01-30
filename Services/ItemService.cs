using rest_api_items.Domain.Models;
using rest_api_items.Domain.Repositories.IRepositories;
using rest_api_items.Services.Communication;
using rest_api_items.Services.IServices;

namespace rest_api_items.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this._itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Item>> ListAsync()
        {
            return await _itemRepository.ListAsync();
        }

        public async Task<ItemResponse> SaveAsync(Item category)
        {
            try
            {
                await _itemRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ItemResponse($"ERROR saving item: {ex.Message}");
            }
        }
    }
}