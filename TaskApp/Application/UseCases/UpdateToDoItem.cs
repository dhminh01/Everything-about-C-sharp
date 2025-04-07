using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class UpdateToDoItem(IToDoRepository toDoRepository)
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task<ToDoItem?> ExecuteAsync(int id, string title, bool isCompleted)
        {
            var toDoItem = await _toDoRepository.GetByIdAsync(id);
            if (toDoItem != null)
            {
                toDoItem.Title = title;
                toDoItem.IsCompleted = isCompleted;
                toDoItem.CreatedDate = DateTime.UtcNow;

                await _toDoRepository.UpdateAsync(toDoItem);
            }

            return toDoItem;
        }
    }
}
