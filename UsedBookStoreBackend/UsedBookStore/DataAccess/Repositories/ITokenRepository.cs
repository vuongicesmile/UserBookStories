using Microsoft.AspNetCore.Identity;

namespace UsedBookStore.DataAccess.Repositories
{
    public interface ITokenRepository
    {
        //when this method is executed as a response, it will give us a token
        // which will be a string. => so this method type is string
        
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
