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

        public async Task<ItemResponse> ListOnlyOneAsync(int id)
        {
            var existingItem = await _itemRepository.FindByIdAsync(id);

            if (existingItem == null) return new ItemResponse("ERROR: Item not found.");

            return new ItemResponse(existingItem);
        }

        public async Task<ItemResponse> SaveAsync(Item item)
        {
            try
            {
                await _itemRepository.AddAsync(item);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(item);
            }
            catch (Exception ex)
            {
                return new ItemResponse($"ERROR saving item: {ex.Message}");
            }
        }

        public async Task<ItemResponse> UpdateAsync(int id, Item item)
        {
            var existingItem = await _itemRepository.FindByIdAsync(id);

            if (existingItem == null) return new ItemResponse("ERROR: Item not found.");

            existingItem.Name = item.Name;
            existingItem.ManufacturerName = item.ManufacturerName;
            existingItem.Model = item.Model;

            try
            {
                _itemRepository.Update(existingItem);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(existingItem);
            }
            catch (Exception ex)
            {
                return new ItemResponse($"ERROR updating item: {ex.Message}");
            }
        }

        public async Task<ItemResponse> DeleteAsync(int id)
        {
            var existingItem = await
            _itemRepository.FindByIdAsync(id);

            if (existingItem == null)
                return new ItemResponse("ERROR: Item not found.");
            try
            {
                _itemRepository.Remove(existingItem);
                await _unitOfWork.CompleteAsync();
                return new ItemResponse(existingItem);
            }
            catch (Exception ex)
            {
                return new ItemResponse($"ERROR deleting item: {ex.Message}");
            }
        }
    }
}