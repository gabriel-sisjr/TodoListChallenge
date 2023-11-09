using Microsoft.EntityFrameworkCore;
using TodoListChallenge.Domain.Interfaces.Repository;
using TodoListChallenge.Domain.Models;

namespace TodoListChallenge.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DBContext _appContext;

        public ToDoRepository(DBContext appContext) => _appContext = appContext;

        public async Task<ToDoEntity> InsertAsync(ToDoEntity toDo)
        {
            await _appContext.ToDos.AddAsync(toDo);
            await _appContext.SaveChangesAsync();

            return toDo;
        }

        public async Task DeleteAsync(int id)
        {
            var x = await _appContext.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            if (x != null)
            {
                _appContext.ToDos.Remove(x);
                await _appContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ToDoEntity>> GetAllAsync(string guidIdUser)
            => await _appContext.ToDos
            .AsNoTrackingWithIdentityResolution()
            .Where(x => x.GuidIdUser == guidIdUser)
            .ToListAsync();

        public async Task MarkAsDoneAsync(int idTodo)
        {
            var x = await _appContext.ToDos.FirstOrDefaultAsync(x => x.Id == idTodo);
            if (x != null)
            {
                x.Status = 1;
                _appContext.ToDos.Update(x);
                await _appContext.SaveChangesAsync();
            }
        }
    }
}
