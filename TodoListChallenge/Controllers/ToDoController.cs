using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoListChallenge.Domain.Interfaces.Repository;
using TodoListChallenge.Domain.Models;

namespace TodoListChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoEntity toDoEntity)
        {
            await _repository.InsertAsync(toDoEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = User.FindFirst(ClaimTypes.SerialNumber)?.Value!;
            var todos = await _repository.GetAllAsync(userId);
            return Ok(todos);
        }
    }
}
