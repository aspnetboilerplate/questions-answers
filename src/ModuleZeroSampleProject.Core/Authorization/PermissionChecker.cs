using Abp.Authorization;
using ModuleZeroSampleProject.Authorization.Roles;
using ModuleZeroSampleProject.Users;

namespace ModuleZeroSampleProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}