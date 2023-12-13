using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ModuleZeroSampleProject.Questions.Dto;

namespace ModuleZeroSampleProject.Questions
{
    public interface IQuestionAppService : IApplicationService
    {
        PagedResultDto<QuestionDto> GetQuestions(GetQuestionsInput input);

        Task CreateQuestion(CreateQuestionInput input);

        GetQuestionOutput GetQuestion(GetQuestionInput input);

        VoteChangeOutput VoteUp(EntityDto input);

        VoteChangeOutput VoteDown(EntityDto input);

        SubmitAnswerOutput SubmitAnswer(SubmitAnswerInput input);

        void AcceptAnswer(EntityDto input);
    }
}
