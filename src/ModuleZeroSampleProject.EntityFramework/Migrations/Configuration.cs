using System;
using System.Data.Entity.Validation;
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

            try
            {
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
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
