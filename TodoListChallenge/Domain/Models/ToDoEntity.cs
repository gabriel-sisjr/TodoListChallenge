namespace TodoListChallenge.Domain.Models
{
    public class ToDoEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int Status { get; set; }
        public string GuidIdUser { get; set; } = null!;
    }

    public class ToDoDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

    public class TodoResponse
    {
        public IEnumerable<ToDoEntity> Data { get; set; }

        public TodoResponse() => Data = Enumerable.Empty<ToDoEntity>();
    }

    public static class ToDoExtensions
    {
        public static ToDoEntity ToEntity(this ToDoDto dto, string guidIdUser)
            => new()
            {
                Id = 0,
                Title = dto.Title,
                Description = dto.Description,
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                Status = 0,
                GuidIdUser = guidIdUser
            };
    }
}
