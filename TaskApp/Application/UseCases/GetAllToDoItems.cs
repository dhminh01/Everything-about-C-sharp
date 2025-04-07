using Domain.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class GetAllToDoItems(IToDoRepository toDoRepository)
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task<IEnumerable<ToDoItem>> ExecuteAsync()
        {

            return await _toDoRepository.GetAllAsync();
        }
    }
}