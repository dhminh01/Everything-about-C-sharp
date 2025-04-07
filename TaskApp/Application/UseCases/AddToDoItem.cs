using Domain.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class AddToDoItem(IToDoRepository toDoRepository)
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task ExecuteAsync(ToDoItem item)
        {
            if (string.IsNullOrEmpty(item.Title))

                throw new ArgumentException("Title cannot be empty.");

            await _toDoRepository.AddAsync(item);
        }
    }
}
