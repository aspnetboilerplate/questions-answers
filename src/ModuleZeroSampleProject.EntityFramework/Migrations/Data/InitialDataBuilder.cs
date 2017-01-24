using System.Linq;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using EntityFramework.DynamicFilters;
using ModuleZeroSampleProject.Authorization;
using ModuleZeroSampleProject.EntityFramework;
using ModuleZeroSampleProject.MultiTenancy;
using ModuleZeroSampleProject.Questions;
using ModuleZeroSampleProject.Users;

namespace ModuleZeroSampleProject.Migrations.Data
{
    public class InitialDataBuilder
    {
        private readonly ModuleZeroSampleProjectDbContext _context;

        public InitialDataBuilder(ModuleZeroSampleProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {









            //Admin for 'Default' tenant

            var question1 = _context.Questions.Add(
                new Question(
                    "What's the answer of ultimate question of life the universe and everything?",
                    "What's the answer of ultimate question of life the universe and everything? Please answer this question!"
                )
            );
            _context.SaveChanges();

            question1.CreatorUserId = 2;
            _context.SaveChanges();
        }



    }
}