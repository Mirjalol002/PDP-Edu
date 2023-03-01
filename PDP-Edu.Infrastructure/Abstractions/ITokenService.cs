using PDP_Edu.Domain.Entities;

namespace PDP_Edu.Infrastructure.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}
