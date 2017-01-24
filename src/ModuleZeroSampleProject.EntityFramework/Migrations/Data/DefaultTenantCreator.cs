using System.Linq;
using ModuleZeroSampleProject.EntityFramework;
using ModuleZeroSampleProject.MultiTenancy;

namespace ModuleZeroSampleProject.Migrations.Data
{
    public class DefaultTenantCreator
    {
        private readonly ModuleZeroSampleProjectDbContext _context;

        public DefaultTenantCreator(ModuleZeroSampleProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant { TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName });
                _context.SaveChanges();
            }
        }
    }
}
