using Microsoft.AspNetCore.Identity;

namespace OwlStock.Infrastructure.Identity
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = $"Имейлът вече е регистриран"
            };
        }
    }
}
