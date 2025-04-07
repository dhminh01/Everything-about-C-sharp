using Domain.Interfaces;

namespace Application.UseCases
{
    public class BulkDeleteToDoItems(IToDoRepository toDoRepository)
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task ExecuteAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())

                throw new ArgumentException("ID list cannot be empty.");

            await _toDoRepository.DeleteRangeAsync(ids);
        }
    }
}
