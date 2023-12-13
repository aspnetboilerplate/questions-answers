using Abp.Application.Services.Dto;

namespace QuestionsAnswers.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

