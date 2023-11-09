using Microsoft.EntityFrameworkCore;
using TodoListChallenge.Domain.Interfaces.Repository;
using TodoListChallenge.Domain.Models;

namespace TodoListChallenge.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DBContext _appContext;

        public ToDoRepository(DBContext appContext) => _appContext = appContext;

        public async Task InsertAsync(ToDoEntity toDo)
        {
            await _appContext.ToDos.AddAsync(toDo);
            await _appContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await _appContext.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo != null)
            {
                _appContext.ToDos.Remove(todo);
                await _appContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ToDoEntity>> GetAllAsync(string guidIdUser)
            => await _appContext.ToDos
            .AsNoTrackingWithIdentityResolution()
            .Where(x => x.GuidIdUser == guidIdUser)
            .ToListAsync();
    }
}
