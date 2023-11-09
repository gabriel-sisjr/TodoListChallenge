namespace TodoListChallenge.Domain.Models
{
    public class TokenInfo
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}
