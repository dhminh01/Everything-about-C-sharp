using Domain.Entities;
using Domain.Interfaces;
using InterfaceAdapters.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly TaskAppDbContext _context;

        public ToDoRepository(TaskAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {

            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {

            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task AddAsync(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            _context.ToDoItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<ToDoItem> items)
        {
            foreach (var item in items)
            {
                item.CreatedDate = DateTime.UtcNow;
            }

            await _context.ToDoItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<int> ids)
        {
            var items = await _context.ToDoItems
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != 0)
            {
                _context.ToDoItems.RemoveRange(items);
                await _context.SaveChangesAsync();
            }
        }
    }
}
