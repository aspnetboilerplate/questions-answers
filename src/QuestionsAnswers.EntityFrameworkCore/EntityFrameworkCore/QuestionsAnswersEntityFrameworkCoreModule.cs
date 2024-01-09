using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using QuestionsAnswers.EntityFrameworkCore.Seed;

namespace QuestionsAnswers.EntityFrameworkCore
{
    [DependsOn(
        typeof(QuestionsAnswersCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class QuestionsAnswersEntityFrameworkCoreModule : AbpModule
    {
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<QuestionsAnswersDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuestionsAnswersEntityFrameworkCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }

    }
}