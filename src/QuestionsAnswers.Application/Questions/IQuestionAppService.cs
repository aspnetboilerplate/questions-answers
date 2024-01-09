using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionsAnswers.Questions.Dto;

namespace QuestionsAnswers.Questions
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
