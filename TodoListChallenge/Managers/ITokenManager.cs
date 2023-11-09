using TodoListChallenge.Domain.Models;

namespace TodoListChallenge.Managers
{
    public interface ITokenManager
    {
        TokenInfo BuildToken(UserApp user, int expirationTime = 24);
    }
}
