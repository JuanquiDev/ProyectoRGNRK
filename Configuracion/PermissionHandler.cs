using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace PE_ServicesClassRCL.Models.Permission
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userRoles = context.User.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();
            var userClaims = context.User.Claims.Where(c => c.Type == "claim").Select(c => c.Value).ToList();

            if (requirement.Roles.Any(role => userRoles.Contains(role)) ||
                requirement.Claims.Any(claim => userClaims.Contains(claim)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
