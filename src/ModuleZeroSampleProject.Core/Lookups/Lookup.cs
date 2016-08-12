using Abp.Domain.Entities;

namespace ModuleZeroSampleProject.Lookups
{
    public class Lookup : Entity<long>
    {
        public string Name { get; set; }
    }
}
