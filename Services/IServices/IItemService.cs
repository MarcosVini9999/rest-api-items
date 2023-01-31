using rest_api_items.Domain.Models;
using rest_api_items.Services.Communication;

namespace rest_api_items.Services.IServices
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> ListAsync();
        Task<ItemResponse> ListOnlyOneAsync(int id);
        Task<ItemResponse> SaveAsync(Item item);
        Task<ItemResponse> UpdateAsync(int id, Item item);
        Task<ItemResponse> DeleteAsync(int id);
    }
}