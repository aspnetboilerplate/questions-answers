using Abp.Application.Services.Dto;
using Abp.Application.Services;
using QuestionsAnswers.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsAnswers.Users
{
    public interface IUserAppService : IApplicationService
    {
        ListResultDto<UserDto> GetUsers();
    }
}
