using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using Swashbuckle.Application;

namespace ModuleZeroSampleProject
{
    [DependsOn(typeof(AbpWebApiModule), typeof(ModuleZeroSampleProjectApplicationModule))]
    public class ModuleZeroSampleProjectWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());


            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ModuleZeroSampleProjectApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
            ConfigureSwaggerUi();
        }
        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "NWT.LED.WebApi");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());


                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    var commentsFileName = "bin\\" + typeof(ModuleZeroSampleProjectApplicationModule).Assembly.GetName().Name +
                                           ".XML";
                    var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    c.IncludeXmlComments(commentsFile);

                })
                .EnableSwaggerUi("docs/{*assetPath}", c =>
                {
                    c.InjectJavaScript(Assembly.GetAssembly(typeof(ModuleZeroSampleProjectWebApiModule)), "ModuleZeroSampleProject.Api.Scripts.Swagger-Custom.js");
                });
        }
    }
}
