using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ModuleZeroSampleProject.Authorization
{
    public class ModuleZeroSampleProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
    

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ??
                        context.CreatePermission(PermissionNames.Pages, L("Pages"));


            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));
            pages.CreateChildPermission(PermissionNames.Pages_Questions_Create, L("Can_create_questions"));
            pages.CreateChildPermission(PermissionNames.Pages_Answers_Delete, L("Can_delete_questions"));
            pages.CreateChildPermission(PermissionNames.Pages_Questions_Delete, L("Can_delete_answers"));
            pages.CreateChildPermission(PermissionNames.Pages_AnswerToQuestions, L("Can_answer_to_questions"));
            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        



        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ModuleZeroSampleProjectConsts.LocalizationSourceName);
        }
    }
}
