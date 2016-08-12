using ModuleZeroSampleProject.Lookups;
using Shouldly;
using Xunit;

namespace ModuleZeroSampleProject.Tests.Lookups
{
    public class LookupService_Tests: SampleProjectTestBase
    {
        private readonly ILookupService _lookupService;

        public LookupService_Tests()
        {
            this._lookupService = LocalIocManager.Resolve<ILookupService>();
        }

        [Fact]
        public void Should_Return_Lookup()
        {
            _lookupService.GetLookup().ShouldNotBeNull();
        }

        [Fact]
        public void Should_Return_Another_Lookup()
        {
            _lookupService.GetAnotherLookup().ShouldNotBeNull();
        }
    }
}