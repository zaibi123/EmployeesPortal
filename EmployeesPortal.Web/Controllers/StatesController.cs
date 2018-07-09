using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesPortal.Web.Models;
using EmployeesPortal.Web.Contexts;
using System.Net;
using EmplyeesPortal.Core;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace EmployeesPortal.Web.Controllers
{
    public class StatesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: States
        public ActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            var state = db.State.Include(s => s.Country);
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(state.ToList());
        }

        // GET: States/Details/5
        public ActionResult Details(long? id)
        {
            if (!IsLoggedIn())
            {

                return RedirectToAction("login", "account");
            }
            if (id == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return HttpNotFound();
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(state);
        }

        // GET: States/Create
        public ActionResult Create()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ViewBag.countryid = new SelectList(db.Country, "id", "iso");
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,abbreviation,countryid,createdonutc,updatedonutc,ipused,userid")] State state)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            var stat = db.State.Where(c => c.name == state.name).FirstOrDefault();
            if (stat != null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                this.ModelState.AddModelError("name", "Sorry, state name already exist.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    state.createdonutc = DateTime.UtcNow;
                    state.updatedonutc = DateTime.UtcNow;
                    state.ipused = Request.UserHostAddress;
                    state.userid = User.Identity.GetUserId();
                    db.State.Add(state);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                    ViewBag.countryid = new SelectList(db.Country, "id", "iso", state.countryid);
                    return View(state);
                }
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ViewBag.countryid = new SelectList(db.Country, "id", "iso", state.countryid);
            return View(state);
        }

        // GET: States/Edit/5
        public ActionResult Edit(long? id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (id == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return HttpNotFound();
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ViewBag.countryid = new SelectList(db.Country, "id", "iso", state.countryid);
            return View(state);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,abbreviation,countryid,createdonutc,updatedonutc,ipused,userid")] State state)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            var stat = db.State.Where(c => c.name == state.name).Count();
            if (stat > 1)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                this.ModelState.AddModelError("name", "Sorry, state name already exist.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    state.updatedonutc = DateTime.UtcNow;
                    state.ipused = Request.UserHostAddress;
                    state.userid = User.Identity.GetUserId();
                    db.Entry(state).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                    ViewBag.countryid = new SelectList(db.Country, "id", "iso", state.countryid);
                    return View(state);
                }
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ViewBag.countryid = new SelectList(db.Country, "id", "iso", state.countryid);
            return View(state);
        }

        // GET: States/Delete/5
        public ActionResult Delete(long? id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (id == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return HttpNotFound();
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            State state = db.State.Find(id);
            db.State.Remove(state);
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
