using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BooksApp.Models;

namespace BooksApp.Controllers
{
    public class BookListController : Controller
    {
        private db_BooksAppEntities db = new db_BooksAppEntities();

        // GET: BookList
        public ActionResult Index()
        {
            return View(db.t_books.ToList());
        }

        // GET: BookList/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_books t_books = db.t_books.Find(id);
            if (t_books == null)
            {
                return HttpNotFound();
            }
            return View(t_books);
        }

        // GET: BookList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookList/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book_id,book_name,buyDate,link")] t_books t_books)
        {
            if (ModelState.IsValid)
            {
                db.t_books.Add(t_books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_books);
        }

        // GET: BookList/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_books t_books = db.t_books.Find(id);
            if (t_books == null)
            {
                return HttpNotFound();
            }
            return View(t_books);
        }

        // POST: BookList/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,book_name,buyDate,link")] t_books t_books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_books);
        }

        // GET: BookList/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_books t_books = db.t_books.Find(id);
            if (t_books == null)
            {
                return HttpNotFound();
            }
            return View(t_books);
        }

        // POST: BookList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            t_books t_books = db.t_books.Find(id);
            db.t_books.Remove(t_books);
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
