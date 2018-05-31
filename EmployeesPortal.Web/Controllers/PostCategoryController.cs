using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesPortal.Web.Models;
using EmployeesPortal.Web.Contexts;
using EmployeesPortal.Web.Helpers;
using EmplyeesPortal.Core;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;

namespace EmployeesPortal.Web.Controllers
{
    [CustomAuthorizeAttribute(Roles = "Admin")]
    public class PostCategoryController : Controller
    {
        // GET: PostCategory
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Department
        public ActionResult Index()
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(db.PostCategory.Where(x => x.isactive == true).ToList());
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Department/Create
        public ActionResult Create()
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View();
        }

        // POST: Admin/Department/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,name,isactive,createdonutc,updatedonutc,ipused,userid")] PostCategory PostCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    PostCategory.createdonutc = DateTime.UtcNow;
                    PostCategory.updatedonutc = DateTime.UtcNow;
                    PostCategory.ipused = Request.UserHostAddress;
                    PostCategory.userid = User.Identity.GetUserId();
                    db.PostCategory.Add(PostCategory);
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCategory PostCategory = db.PostCategory.Find(id);
            if (PostCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(PostCategory);
        }

        // POST: Admin/Department/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,name,isactive,createdonutc,updatedonutc,ipused,userid")] PostCategory PostCategory)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    PostCategory.updatedonutc = DateTime.UtcNow;
                    PostCategory.ipused = Request.UserHostAddress;
                    PostCategory.userid = User.Identity.GetUserId();
                    db.Entry(PostCategory).State = EntityState.Modified; ;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PostCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostCategory/Delete/5
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
