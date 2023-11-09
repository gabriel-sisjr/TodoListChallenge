using Microsoft.AspNetCore.Identity;

namespace TodoListChallenge.Domain.Models
{
    public class UserApp : IdentityUser
    {
        public string GuidId { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
