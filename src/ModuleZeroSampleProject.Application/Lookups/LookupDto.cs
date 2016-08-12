using Abp.AutoMapper;

namespace ModuleZeroSampleProject.Lookups
{
    [AutoMapFrom(typeof(Lookup))]
    public class LookupDto
    {
        public string Name { get; set; }
    }

    public interface ILookupService
    {
        LookupDto GetLookup();
        LookupDto GetAnotherLookup();
    }
}