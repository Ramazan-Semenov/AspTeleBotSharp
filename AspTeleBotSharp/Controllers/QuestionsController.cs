using AspTeleBotSharp.Models.Entity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspTeleBotSharp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly u1416851_DataBase1Entities db = new u1416851_DataBase1Entities();

        // GET: Questions
        public async Task<ActionResult> Index()
        {
            return View(await db.Questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = await db.Questions.FindAsync(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.Box = db.QuestionsBox.Select(x => x.Name).ToArray();

            ViewBag.Type = new[] { "String", "Int", "Date" };

            return View();
        }

        // POST: Questions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,replyMarkupBox,Text,replyToMessageId,box,Image,Type,file")] Questions questions, HttpPostedFileBase file, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {

                Questions ques = new Questions()
                {
                    Id = questions.Id,
                    replyMarkupBox = questions.replyMarkupBox,
                    Text = questions.Text,
                    replyToMessageId = questions.replyToMessageId,
                    box = questions.box,
                    Type = questions.Type
                };
                if ((file != null) )
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    // сохраняем файл в папку Files в проекте
                    file.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + fileName);
                    ques.file = file.FileName;

                }
                else
                {
                    ques.file = "";
                }
                if (Image != null)
                {
                    string fileN = System.IO.Path.GetFileName(Image.FileName);
                    // сохраняем файл в папку Files в проекте
                    Image.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Image\\" + fileN);
                    ques.Image = Image.FileName;
                }
                else
                {
                    ques.Image = "";
                }
                if (ques != null)
                {
                    db.Questions.Add(ques);
                    await db.SaveChangesAsync();
                }



                return RedirectToAction("Index");
            }

            return View(questions);
        }

        // GET: Questions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = await db.Questions.FindAsync(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        // POST: Questions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,replyMarkupBox,Text,replyToMessageId,box,Image,Type,file")] Questions questions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(questions);
        }

        // GET: Questions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = await db.Questions.FindAsync(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Questions questions = await db.Questions.FindAsync(id);
            db.Questions.Remove(questions);
            await db.SaveChangesAsync();
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
