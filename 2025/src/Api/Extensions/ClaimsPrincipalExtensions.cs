using System.Security.Claims;

namespace Application.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetId(this ClaimsPrincipal claimsPrincipal)
    {
        var idClaim = claimsPrincipal.FindFirst("Id");
        if (idClaim == null)
            return null;

        return Guid.TryParse(idClaim.Value, out var id) ? id : null;
    }
}