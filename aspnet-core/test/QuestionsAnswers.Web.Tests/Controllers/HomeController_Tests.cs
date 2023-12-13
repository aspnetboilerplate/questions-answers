using System.Threading.Tasks;
using QuestionsAnswers.Models.TokenAuth;
using QuestionsAnswers.Web.Controllers;
using Shouldly;
using Xunit;

namespace QuestionsAnswers.Web.Tests.Controllers
{
    public class HomeController_Tests: QuestionsAnswersWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}