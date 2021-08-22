using AspTeleBotSharp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace AspTeleBotSharp.Controllers
{
    public class MessageController : Controller
    {
        //public ObservableCollection<BotUser> UsList { get => UserContext.Users; set { UserContext.Users = value; OnPropertyChanged(nameof(UsList));*/ } }
        private static readonly Models.ViewModel.ViewModelMainWindow window = new Models.ViewModel.ViewModelMainWindow();
        private readonly List<BotUser> x = window.UsList.ToList();
        // GET: Message
        public ActionResult Index()
        {

            Thread thread = new Thread(resive);
            thread.Start();
            return View(window.UsList.ToList());


        }

        private void resive()
        {
            while (true)
            {

                Redirect("Index");

            }
        }


        // GET: Message/Details/5
        public ActionResult Reload()
        {
            List<BotUser> x = window.UsList.ToList();
            return PartialView();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Message/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
