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
    public class CountriesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Countries
        public ActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(db.Country.ToList());
        }

        // GET: Countries/Details/5
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
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,iso,iso3,name,nicename,numcode,phonecode,createdonutc,updatedonutc,ipused,userid")] Country country)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            // Validate if Entity is not duplicate.
            var ecountry = db.Country.Where(c => c.name == country.name).FirstOrDefault();
            if (ecountry != null)
            {
                this.ModelState.AddModelError("name", "Sorry, country name already exist.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    country.createdonutc = DateTime.UtcNow;
                    country.updatedonutc = DateTime.UtcNow;
                    country.ipused = Request.UserHostAddress;
                    country.userid = User.Identity.GetUserId();
                    db.Country.Add(country);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", ex.Message);
                    return View(country);
                }
            }

            return View(country);
        }

        // GET: Countries/Edit/5
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
            Country country = db.Country.Find(id);
            if (country == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return HttpNotFound();
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,iso,iso3,name,nicename,numcode,phonecode,createdonutc,updatedonutc,ipused,userid")] Country country)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            var ecountry = db.Country.Where(c => c.name == country.name).Count();
            if (ecountry > 1)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                this.ModelState.AddModelError("name", "Sorry, country name already exist.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    country.updatedonutc = DateTime.UtcNow;
                    country.ipused = Request.UserHostAddress;
                    country.userid = User.Identity.GetUserId();
                    db.Entry(country).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                    return View(country);
                }
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(country);
            
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(long? id)
        {
            if (!IsLoggedIn())
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return RedirectToAction("login", "account");
            }
            if (id == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Country.Find(id);
            if (country == null)
            {
                ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
                return HttpNotFound();
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(country);
            
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            Country country = db.Country.Find(id);
            db.Country.Remove(country);
            db.SaveChanges();
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
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
