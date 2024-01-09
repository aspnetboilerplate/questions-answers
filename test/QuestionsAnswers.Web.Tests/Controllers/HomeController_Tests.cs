using System.Threading.Tasks;
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
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
