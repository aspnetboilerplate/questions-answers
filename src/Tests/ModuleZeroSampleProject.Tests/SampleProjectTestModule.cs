using Abp.Modules;
using Abp.TestBase;

namespace ModuleZeroSampleProject.Tests
{
    [DependsOn(
         typeof(AbpTestBaseModule),
         typeof(ModuleZeroSampleProjectApplicationModule),
         typeof(ModuleZeroSampleProjectDataModule)
     )]
    public class SampleProjectTestModule : AbpModule
    {
        
    }
}