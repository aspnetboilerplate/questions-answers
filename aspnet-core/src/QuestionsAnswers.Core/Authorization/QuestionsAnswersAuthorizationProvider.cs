using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace QuestionsAnswers.Authorization
{
    public class QuestionsAnswersAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.Pages_Questions_Create, L("QuestionsCreate"));
            context.CreatePermission(PermissionNames.Pages_Questions_Edit, L("QuestionsEdit"));
            context.CreatePermission(PermissionNames.Pages_Questions_Delete, L("QuestionsDelete"));
            context.CreatePermission(PermissionNames.Pages_Answers_Delete, L("AnswersDelete"));
            context.CreatePermission(PermissionNames.Pages_AnswerToQuestions, L("AnswerToQuestion"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, QuestionsAnswersConsts.LocalizationSourceName);
        }
    }
}
