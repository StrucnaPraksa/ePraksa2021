using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace PracticeManagement.Core.Helpers
{
    public static class IdentityHelpers
    {
        public static string GetUserId(IPrincipal principal)
        {
            var claimsIdentity = principal.Identity as ClaimsIdentity;
            return claimsIdentity.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
