using TodoListChallenge.Domain.Models;

namespace TodoListChallenge.Domain.Interfaces.Repository
{
    public interface IToDoRepository
    {
        Task InsertAsync(ToDoEntity toDo);
        Task<IEnumerable<ToDoEntity>> GetAllAsync(string guidIdUser);
        Task DeleteAsync(int id);
    }
}
