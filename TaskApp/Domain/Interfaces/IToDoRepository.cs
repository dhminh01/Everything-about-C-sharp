using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(int id);
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
        Task DeleteAsync(int id);
        Task AddRangeAsync(IEnumerable<ToDoItem> items);
        Task DeleteRangeAsync(IEnumerable<int> ids);
    }
}
