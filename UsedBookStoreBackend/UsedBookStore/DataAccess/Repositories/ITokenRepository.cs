using Microsoft.AspNetCore.Identity;

namespace UsedBookStore.DataAccess.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
