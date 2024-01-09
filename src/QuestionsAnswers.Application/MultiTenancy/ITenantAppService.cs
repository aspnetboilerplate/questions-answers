using Abp.Application.Services;
using QuestionsAnswers.MultiTenancy.Dto;

namespace QuestionsAnswers.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
