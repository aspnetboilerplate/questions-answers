using Abp.Authorization.Roles;
using QuestionsAnswers.Users;

namespace QuestionsAnswers.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        public Role()
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
    }
}
