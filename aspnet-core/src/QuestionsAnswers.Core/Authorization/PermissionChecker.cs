using Abp.Authorization;
using QuestionsAnswers.Authorization.Roles;
using QuestionsAnswers.Authorization.Users;

namespace QuestionsAnswers.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
