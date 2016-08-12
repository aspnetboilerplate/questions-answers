using Abp.Application.Services;
using Abp.AutoMapper;

namespace ModuleZeroSampleProject.Lookups
{
    public class LookupService : ApplicationService, ILookupService
    {
        public LookupDto GetLookup()
        {
            var lookup = new Lookup { Name = "Test" };

            return lookup.MapTo<LookupDto>();
        }

        public LookupDto GetAnotherLookup()
        {
            var lookup = new Lookup { Name = "Test" };

            return lookup.MapTo<LookupDto>();
        }
    }
}