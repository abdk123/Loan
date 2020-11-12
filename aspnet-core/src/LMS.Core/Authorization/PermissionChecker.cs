using Abp.Authorization;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;

namespace LMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
