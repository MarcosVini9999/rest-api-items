using rest_api_items.Domain.Models;

namespace rest_api_items.Domain.Repositories.IRepositories
{
    public interface  IItemRepository
    {
        Task<IEnumerable<Item>> ListAsync();
        Task AddAsync(Item item);
    }
}