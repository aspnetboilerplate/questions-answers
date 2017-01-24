using EntityFramework.DynamicFilters;
using ModuleZeroSampleProject.EntityFramework;

namespace ModuleZeroSampleProject.Migrations.Data
{
    public class InitialHostDbBuilder
    {
        private readonly ModuleZeroSampleProjectDbContext _context;

        public InitialHostDbBuilder(ModuleZeroSampleProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
