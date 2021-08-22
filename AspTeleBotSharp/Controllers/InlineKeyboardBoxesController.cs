﻿using AspTeleBotSharp.Models.Entity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspTeleBotSharp.Controllers
{
    public class InlineKeyboardBoxesController : Controller
    {
        private readonly u1416851_DataBase1Entities db = new u1416851_DataBase1Entities();

        // GET: InlineKeyboardBoxes
        public ActionResult Index()
        {
            return View(db.InlineKeyboardBox.ToList());
        }

        // GET: InlineKeyboardBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InlineKeyboardBox inlineKeyboardBox = db.InlineKeyboardBox.Find(id);
            if (inlineKeyboardBox == null)
            {
                return HttpNotFound();
            }
            return View(inlineKeyboardBox);
        }

        // GET: InlineKeyboardBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InlineKeyboardBoxes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] InlineKeyboardBox inlineKeyboardBox)
        {
            if (ModelState.IsValid)
            {
                db.InlineKeyboardBox.Add(inlineKeyboardBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inlineKeyboardBox);
        }

        // GET: InlineKeyboardBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InlineKeyboardBox inlineKeyboardBox = db.InlineKeyboardBox.Find(id);
            if (inlineKeyboardBox == null)
            {
                return HttpNotFound();
            }
            return View(inlineKeyboardBox);
        }

        // POST: InlineKeyboardBoxes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] InlineKeyboardBox inlineKeyboardBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inlineKeyboardBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inlineKeyboardBox);
        }

        // GET: InlineKeyboardBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InlineKeyboardBox inlineKeyboardBox = db.InlineKeyboardBox.Find(id);
            if (inlineKeyboardBox == null)
            {
                return HttpNotFound();
            }
            return View(inlineKeyboardBox);
        }

        // POST: InlineKeyboardBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InlineKeyboardBox inlineKeyboardBox = db.InlineKeyboardBox.Find(id);
            db.InlineKeyboardBox.Remove(inlineKeyboardBox);
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
