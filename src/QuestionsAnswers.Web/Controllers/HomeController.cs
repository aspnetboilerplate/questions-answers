using Microsoft.AspNetCore.Mvc;

namespace QuestionsAnswers.Web.Controllers
{
    public class HomeController : QuestionsAnswersControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}