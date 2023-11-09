using TodoListChallenge.Domain.Models;

namespace TodoListChallenge.Domain.Interfaces.Repository
{
    public interface IToDoRepository
    {
        Task<ToDoEntity> InsertAsync(ToDoEntity toDo);
        Task MarkAsDoneAsync(int idTodo);
        Task<IEnumerable<ToDoEntity>> GetAllAsync(string guidIdUser);
        Task DeleteAsync(int id);
    }
}
