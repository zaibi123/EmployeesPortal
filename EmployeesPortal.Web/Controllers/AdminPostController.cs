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
    public class AdminPostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Post
        public ActionResult Index()
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();

            return View(db.Post.Where(x=>x.isactive== true).ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            // TODO: Add insert logic here
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ViewBag.departmentid = new SelectList(db.Department.Where(x => x.isactive == true), "id", "name");
            ViewBag.postcategoryid = new SelectList(db.PostCategory.Where(x => x.isactive == true), "id", "name");
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
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
