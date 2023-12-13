using System.Threading.Tasks;
using Abp.Application.Services;
using QuestionsAnswers.Sessions.Dto;

namespace QuestionsAnswers.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
