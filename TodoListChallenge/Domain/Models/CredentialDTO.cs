namespace TodoListChallenge.Domain.Models
{
    public class CredentialDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class UserDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public static class UserExtension
    {
        public static UserApp ToEntityUser(this UserDTO userDTO) 
            => new() { UserName = userDTO.Username, Name = userDTO.Name, GuidId = Guid.NewGuid().ToString() };
    }
}
