using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ModuleZeroSampleProject.Authorization
{
    public class ModuleZeroSampleProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
    

            var pages = context.GetPermissionOrNull(PermissionNames.Pages);


            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            pages.CreateChildPermission("CanCreateQuestions", new FixedLocalizableString("Can create questions"));
            pages.CreateChildPermission("CanDeleteQuestions", new FixedLocalizableString("Can delete questions"));
            pages.CreateChildPermission("CanDeleteAnswers", new FixedLocalizableString("Can delete answers"));
            pages.CreateChildPermission("CanAnswerToQuestions", new FixedLocalizableString("Can answer to questions"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ModuleZeroSampleProjectConsts.LocalizationSourceName);
        }
    }
}
