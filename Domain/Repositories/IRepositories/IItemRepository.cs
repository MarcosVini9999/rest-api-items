using rest_api_items.Domain.Models;

namespace rest_api_items.Domain.Repositories.IRepositories
{
    public interface  IItemRepository
    {
        Task<IEnumerable<Item>> ListAsync();
        Task AddAsync(Item item);
        Task<Item> FindByIdAsync(int id);
        void Update(Item item);
        void Remove(Item item);
    }
}