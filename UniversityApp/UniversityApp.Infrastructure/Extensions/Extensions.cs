using System.Security.Claims;

namespace UniversityApp.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static int GetUserId(this System.Security.Principal.IPrincipal user)
        {
            return Convert.ToInt32(((ClaimsIdentity)user.Identity).Claims.FirstOrDefault(p => p.Type == "UserId")?.Value);
        }

        public static string GetUserRole(this System.Security.Principal.IPrincipal user)
        {
            return ((ClaimsIdentity)user.Identity).Claims.FirstOrDefault(p => p.Type == ClaimTypes.Role)?.Value;
        }

        public static string GetUsername(this System.Security.Principal.IPrincipal user)
        {
            return ((ClaimsIdentity)user.Identity).Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
        }
    }
}
