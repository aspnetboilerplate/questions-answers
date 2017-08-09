using System;
using System.Data.Common;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using ModuleZeroSampleProject.EntityFramework;
using ModuleZeroSampleProject.Migrations.Data;

namespace ModuleZeroSampleProject.Tests
{
    public abstract class SampleProjectTestBase : AbpIntegratedTestBase<SampleProjectTestModule>
    {
        protected SampleProjectTestBase()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            //Creating initial data
            UsingDbContext(context => new InitialDataBuilder(context));
            
            AbpSession.TenantId = 1;
        }

        public void UsingDbContext(Action<ModuleZeroSampleProjectDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<ModuleZeroSampleProjectDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<ModuleZeroSampleProjectDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ModuleZeroSampleProjectDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
