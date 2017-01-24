using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Zero.Configuration;

namespace ModuleZeroSampleProject.Web
{
    [DependsOn(
         typeof(ModuleZeroSampleProjectDataModule),
        typeof(ModuleZeroSampleProjectApplicationModule),
        typeof(ModuleZeroSampleProjectWebApiModule),
        typeof(AbpWebMvcModule))]
    public class ModuleZeroSampleProjectWebModule : AbpModule
    {
        public override void PreInitialize()
        {

            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

    



            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<ModuleZeroSampleProjectNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
