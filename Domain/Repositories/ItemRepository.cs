using Microsoft.EntityFrameworkCore;
using rest_api_items.Domain.Models;
using rest_api_items.Domain.Repositories.IRepositories;
using rest_api_items.Persistence.Contexts;

namespace rest_api_items.Domain.Repositories
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Item>> ListAsync()
        {
            return await _context.Items.ToListAsync();
        }
    }
}