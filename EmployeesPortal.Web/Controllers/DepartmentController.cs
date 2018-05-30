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
    public class DepartmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Department
        public ActionResult Index()
        {
            return View(db.Department.Where(x => x.isactive == true).ToList());
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Department/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,name,isactive,createdonutc,updatedonutc,ipused,userid")] Department Departments)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Departments.createdonutc = DateTime.UtcNow;
                    Departments.updatedonutc = DateTime.UtcNow;
                    Departments.ipused = Request.UserHostAddress;
                    Departments.userid = User.Identity.GetUserId();
                    db.Department.Add(Departments);
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
            Department Departments = db.Department.Find(id);
            if (Departments == null)
            {
                return HttpNotFound();
            }
            return View(Departments);
        }

        // POST: Admin/Department/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,name,isactive,createdonutc,updatedonutc,ipused,userid")] Department Departments)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Departments.updatedonutc = DateTime.UtcNow;
                    Departments.ipused = Request.UserHostAddress;
                    Departments.userid = User.Identity.GetUserId();
                    db.Entry(Departments).State = EntityState.Modified; ;
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
