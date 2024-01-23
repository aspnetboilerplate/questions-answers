using Abp.MultiTenancy;
using QuestionsAnswers.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsAnswers.MultiTenancy
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
