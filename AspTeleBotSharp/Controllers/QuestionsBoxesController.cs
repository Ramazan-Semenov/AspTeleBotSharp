using AspTeleBotSharp.Models.Entity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspTeleBotSharp.Controllers
{
    public class QuestionsBoxesController : Controller
    {
        private readonly u1416851_DataBase1Entities db = new u1416851_DataBase1Entities();

        // GET: QuestionsBoxes
        public ActionResult Index()
        {
            return View(db.QuestionsBox.ToList());
        }

        // GET: QuestionsBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionsBox questionsBox = db.QuestionsBox.Find(id);
            if (questionsBox == null)
            {
                return HttpNotFound();
            }
            return View(questionsBox);
        }

        // GET: QuestionsBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionsBoxes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] QuestionsBox questionsBox)
        {
            if (ModelState.IsValid)
            {
                db.QuestionsBox.Add(questionsBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionsBox);
        }

        // GET: QuestionsBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionsBox questionsBox = db.QuestionsBox.Find(id);
            if (questionsBox == null)
            {
                return HttpNotFound();
            }
            return View(questionsBox);
        }

        // POST: QuestionsBoxes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] QuestionsBox questionsBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionsBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionsBox);
        }

        // GET: QuestionsBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionsBox questionsBox = db.QuestionsBox.Find(id);
            if (questionsBox == null)
            {
                return HttpNotFound();
            }
            return View(questionsBox);
        }

        // POST: QuestionsBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionsBox questionsBox = db.QuestionsBox.Find(id);
            db.QuestionsBox.Remove(questionsBox);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
