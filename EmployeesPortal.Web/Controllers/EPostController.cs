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
    public class EPostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: EmpPost
        public ActionResult Index()
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View();
        }

        // GET: EmpPost/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpPost/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpPost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpPost/Edit/5
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

        // GET: EmpPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpPost/Delete/5
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
