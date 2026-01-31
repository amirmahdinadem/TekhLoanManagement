using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                         ?? user.FindFirstValue(JwtRegisteredClaimNames.Sub);

            return Guid.Parse(userId);
        }
    }

}
