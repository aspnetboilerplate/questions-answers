using Abp.MultiTenancy;
using ModuleZeroSampleProject.Users;

namespace ModuleZeroSampleProject.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {

        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}