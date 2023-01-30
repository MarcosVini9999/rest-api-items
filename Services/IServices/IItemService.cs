using rest_api_items.Domain.Models;

namespace rest_api_items.Services.IServices
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> ListAsync();
    }
}