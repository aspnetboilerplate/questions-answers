using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.AutoMapper;
using QuestionsAnswers.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsAnswers.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly UserManager _userManager;

        public UserAppService(UserManager userManager)
        {
            _userManager = userManager;
        }

        public ListResultDto<UserDto> GetUsers()
        {
            return new ListResultDto<UserDto>
            {
                Items = _userManager.Users.ToList().MapTo<List<UserDto>>()
            };
        }
    }
}
