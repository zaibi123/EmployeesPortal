﻿using System;
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
    [CustomAuthorizeAttribute(Roles = "Admin,Employee")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
