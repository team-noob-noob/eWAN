using System.Security.Claims;

namespace eWAN.WebApi.Modules
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal) =>
            int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
