using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using ModuleZeroSampleProject.Authorization;
using ModuleZeroSampleProject.Configuration;
using ModuleZeroSampleProject.Questions.Dto;
using ModuleZeroSampleProject.Users;

namespace ModuleZeroSampleProject.Questions
{
    [AbpAuthorize]
    public class QuestionAppService : ApplicationService, IQuestionAppService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Answer> _answerRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Vote, long> _voteRepository;
        private readonly QuestionDomainService _questionDomainService;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public QuestionAppService(IRepository<Question> questionRepository, IRepository<Answer> answerRepository, IRepository<User, long> userRepository, QuestionDomainService questionDomainService, IUnitOfWorkManager unitOfWorkManager, IRepository<Vote, long> voteRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _userRepository = userRepository;
            _questionDomainService = questionDomainService;
            _unitOfWorkManager = unitOfWorkManager;
            _voteRepository = voteRepository;
        }

        public PagedResultDto<QuestionDto> GetQuestions(GetQuestionsInput input)
        {
            if (input.MaxResultCount <= 0)
            {
                input.MaxResultCount = SettingManager.GetSettingValue<int>(MySettingProvider.QuestionsDefaultPageSize);
            }

            var questionCount = _questionRepository.Count();
            var questions =
                _questionRepository
                    .GetAll()
                    .Include(q => q.CreatorUser)
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToList();

            return new PagedResultDto<QuestionDto>
            {
                TotalCount = questionCount,
                Items = questions.MapTo<List<QuestionDto>>()
            };
        }

        [AbpAuthorize(PermissionNames.Pages_Questions_Create)] //An example of permission checking
        public async Task CreateQuestion(CreateQuestionInput input)
        {
            await _questionRepository.InsertAsync(new Question(input.Title, input.Text));
        }

        public GetQuestionOutput GetQuestion(GetQuestionInput input)
        {
            var question =
                _questionRepository
                    .GetAll()
                    .Include(q => q.CreatorUser)
                    .Include(q => q.Answers)
                    .Include("Answers.CreatorUser")
                    .FirstOrDefault(q => q.Id == input.Id);

            if (question == null)
            {
                throw new UserFriendlyException("There is no such a question. Maybe it's deleted.");
            }

            if (input.IncrementViewCount)
            {
                question.ViewCount++;
            }

            return new GetQuestionOutput
            {
                Question = question.MapTo<QuestionWithAnswersDto>()
            };
        }

        public VoteChangeOutput VoteUp(EntityDto input)
        {
            return Vote(input.Id, true);
        }

        public VoteChangeOutput VoteDown(EntityDto input)
        {
            return Vote(input.Id, false);
        }

        private VoteChangeOutput Vote(int id, bool voteUp)
        {
            var question = _questionRepository.Get(id);
            if (!SettingManager.GetSettingValue<bool>(MySettingProvider.AllowMultipleVote))
            {
                var voterId = AbpSession.UserId;
                var vote = _voteRepository.GetAll().FirstOrDefault(v => v.UserId == voterId && v.QuestionId == id);

                if (vote != null)
                {
                    if (vote.UpVote != voteUp)
                    {
                        //this is undo vote which delete previous vote
                        _voteRepository.Delete(vote);
                        question.VoteCount += (voteUp ? 1 : -1);
                    }
                    return new VoteChangeOutput(question.VoteCount);
                }
                _voteRepository.Insert(new Vote
                {
                    UpVote = voteUp,
                    QuestionId = question.Id,
                    UserId = voterId.Value
                });
            }
            question.VoteCount += (voteUp ? 1 : -1);
            return new VoteChangeOutput(question.VoteCount);
        }

        [AbpAuthorize(PermissionNames.Pages_AnswerToQuestions)]
        public SubmitAnswerOutput SubmitAnswer(SubmitAnswerInput input)
        {
            var question = _questionRepository.Get(input.QuestionId);
            var currentUser = _userRepository.Get(AbpSession.GetUserId());

            question.AnswerCount++;

            var answer = _answerRepository.Insert(
                new Answer(input.Text)
                {
                    Question = question,
                    CreatorUser = currentUser
                });

            _unitOfWorkManager.Current.SaveChanges();

            return new SubmitAnswerOutput
            {
                Answer = answer.MapTo<AnswerDto>()
            };
        }

        public void AcceptAnswer(EntityDto input)
        {
            var answer = _answerRepository.Get(input.Id);
            _questionDomainService.AcceptAnswer(answer);
        }
    }
}