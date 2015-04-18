using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Notes.Models;
using Notes.DAL;
using Newtonsoft.Json;

namespace Notes.Controllers
{
    public class DirectoryController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: /Directory/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Directory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            return View(directory);
        }

        // GET: /Directory/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.Directories, "Id", "Name");
            return View();
        }

        // POST: /Directory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ParentId")] Directory directory)
        {
            if (ModelState.IsValid)
            {
                db.Directories.Add(directory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.Directories, "Id", "Name", directory.ParentId);
            return View(directory);
        }

        // GET: /Directory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.Directories, "Id", "Name", directory.ParentId);
            return View(directory);
        }

        // POST: /Directory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ParentId")] Directory directory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.Directories, "Id", "Name", directory.ParentId);
            return View(directory);
        }

        // GET: /Directory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            return View(directory);
        }

        // POST: /Directory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Directory directory = db.Directories.Find(id);
            db.Directories.Remove(directory);
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

        public string GetDirectories(int id = 0)
        {
            var directories = db.Directories.Where(d => d.ParentId.Equals(id)).Where(d => !d.Id.Equals(0)).ToList();

            return JsonConvert.SerializeObject(new { parentId = id, directorylist = directories }, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        public string GoTo(int id = 0)
        {
            var directory = db.Directories.Find(id);
            var directories = db.Directories.Where(d => d.ParentId.Equals(directory.ParentId)).Where(d => !d.Id.Equals(0)).ToList();

            return JsonConvert.SerializeObject(new {parentId = directory.ParentId, directorylist = directories }, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }
    }
}
