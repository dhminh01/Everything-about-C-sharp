using Domain.Interfaces;

namespace Application.UseCases
{
    public class DeleteToDoItem(IToDoRepository toDoRepository)
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task<bool> ExecuteAsync(int id)
        {
            var toDoItem = await _toDoRepository.GetByIdAsync(id);
            if (toDoItem != null)
            {
                await _toDoRepository.DeleteAsync(id);

                return true;
            }

            return false;
        }
    }

}
