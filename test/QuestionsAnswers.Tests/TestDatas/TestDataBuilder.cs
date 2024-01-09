using QuestionsAnswers.EntityFrameworkCore;

namespace QuestionsAnswers.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly QuestionsAnswersDbContext _context;

        public TestDataBuilder(QuestionsAnswersDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}