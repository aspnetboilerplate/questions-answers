using Abp.MultiTenancy;
using EntityFramework.DynamicFilters;
using ModuleZeroSampleProject.EntityFramework;
using ModuleZeroSampleProject.Migrations.Data;

namespace ModuleZeroSampleProject.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ModuleZeroSampleProjectDbContext>
    {
        public AbpTenantBase Tenant { get; set; }
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ModuleZeroSampleProject";
        }

        protected override void Seed(ModuleZeroSampleProject.EntityFramework.ModuleZeroSampleProjectDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
