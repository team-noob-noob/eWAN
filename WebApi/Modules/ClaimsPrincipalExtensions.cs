using System.Security.Claims;

namespace eWAN.WebApi.Modules
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
