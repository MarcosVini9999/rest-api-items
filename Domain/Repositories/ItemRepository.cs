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

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
        }

        public async Task<Item> FindByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public void Update(Item item)
        {
            _context.Items.Update(item);
        }

        public void Remove(Item item)
        {
            _context.Items.Remove(item);
        }

    }
}