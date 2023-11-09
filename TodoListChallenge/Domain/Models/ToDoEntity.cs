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

    public class TodoResponse
    {
        public IEnumerable<ToDoEntity> Data { get; set; }

        public TodoResponse() => Data = Enumerable.Empty<ToDoEntity>();
    }
}
