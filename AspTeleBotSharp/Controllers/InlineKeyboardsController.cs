using AspTeleBotSharp.Models.Entity;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspTeleBotSharp.Controllers
{
    public class InlineKeyboardsController : Controller
    {
        private readonly u1416851_DataBase1Entities db = new u1416851_DataBase1Entities();

        // GET: InlineKeyboards
        public async Task<ActionResult> Index()
        {
            return View(await db.InlineKeyboard.ToListAsync());
        }

        // GET: InlineKeyboards/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InlineKeyboard inlineKeyboard = await db.InlineKeyboard.FindAsync(id);
            if (inlineKeyboard == null)
            {
                return HttpNotFound();
            }
            return View(inlineKeyboard);
        }

        // GET: InlineKeyboards/Create
        public ActionResult Create()
        {
            ViewBag.Box = db.InlineKeyboardBox.Select(x => x.Name).ToArray();
            return View();
        }

        // POST: InlineKeyboards/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Questionsid,Text,CallBackData,box,Image,Type,file")] InlineKeyboard inlineKeyboard)
        {
            if (ModelState.IsValid)
            {
                db.InlineKeyboard.Add(inlineKeyboard);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inlineKeyboard);
        }

        // GET: InlineKeyboards/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InlineKeyboard inlineKeyboard = await db.InlineKeyboard.FindAsync(id);
            if (inlineKeyboard == null)
            {
                return HttpNotFound();
            }
            return View(inlineKeyboard);
        }

        // POST: InlineKeyboards/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Questionsid,Text,CallBackData,box,Image,Type,file")] InlineKeyboard inlineKeyboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inlineKeyboard).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inlineKeyboard);
        }

        // GET: InlineKeyboards/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InlineKeyboard inlineKeyboard = await db.InlineKeyboard.FindAsync(id);
            if (inlineKeyboard == null)
            {
                return HttpNotFound();
            }
            return View(inlineKeyboard);
        }

        // POST: InlineKeyboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InlineKeyboard inlineKeyboard = await db.InlineKeyboard.FindAsync(id);
            db.InlineKeyboard.Remove(inlineKeyboard);
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
