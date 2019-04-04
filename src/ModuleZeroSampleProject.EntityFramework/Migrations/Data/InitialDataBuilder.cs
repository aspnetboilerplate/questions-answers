using ModuleZeroSampleProject.EntityFramework;
using ModuleZeroSampleProject.Questions;

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