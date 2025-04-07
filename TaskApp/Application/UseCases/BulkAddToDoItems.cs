using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class BulkAddToDoItems(IToDoRepository toDoRepository)
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task ExecuteAsync(IEnumerable<ToDoItem> items)
        {
            if (items == null || !items.Any())

                throw new ArgumentException("Item list cannot be empty.");

            foreach (var item in items)
            {
                if (string.IsNullOrWhiteSpace(item.Title))

                    throw new ArgumentException("Each task must have a title.");
            }

            await _toDoRepository.AddRangeAsync(items);
        }
    }

}
