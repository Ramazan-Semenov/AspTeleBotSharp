using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspTeleBotSharp.Controllers
{
    public class HomeController : Controller
    {
        [Obsolete]

        private static string state = "";
        public async Task<ActionResult> Index()
        {
            ViewBag.state = state;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Start()


        {
            if (Models.TeleBot.Bot.IsReceiving == false)
            {
                await Task.Run(() => new Models.BotStart.StartBot().start());

                state = "Бот запущен";
            }


            return Redirect("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Stop()
        {
            if (Models.TeleBot.Bot.IsReceiving != false)
            {
                await Task.Run(() => new Models.BotStart.StartBot().stop().Dispose());

                state = "Бот остановлен";
            }
            return Redirect("Index");
        }
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}