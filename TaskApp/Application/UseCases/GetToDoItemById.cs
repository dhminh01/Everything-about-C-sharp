using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class GetToDoItemById(IToDoRepository toDoRepository)
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task<ToDoItem> ExecuteAsync(int id)
        {

            return await _toDoRepository.GetByIdAsync(id);
        }
    }
}
