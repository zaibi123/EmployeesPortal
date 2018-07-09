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
        public ActionResult Index(int id)
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            var categorytype = db.PostCategory.Find(id);
            ViewBag.postcategoryType = categorytype.name;
            ViewBag.postcategoryid = categorytype.id;
            return View(db.Post.Where(x=>x.isactive== true && x.postcategoryid==id).ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult View(int id)
        {
            PostCommentVM postcomment = new PostCommentVM();
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            postcomment.commentlist = db.Comments.Where(x => x.postid == id).ToList();
            postcomment.Post = db.Post.Find(id);
            var categorytype = db.PostCategory.Find(postcomment.Post.postcategoryid);
            ViewBag.postcategoryType = categorytype.name;
            ViewBag.postcategoryid = categorytype.id;
            return View(postcomment);
           // return View();
        }
        // GET: Post/Create
        public ActionResult Create(int id)
        {
            // TODO: Add insert logic here
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ViewBag.departmentid = new SelectList(db.Department.Where(x => x.isactive == true), "id", "name");
            ViewBag.postcategoryid = new SelectList(db.PostCategory.Where(x => x.isactive == true), "id", "name");
            var categorytype = db.PostCategory.Find(id);
            ViewBag.postcategoryType = categorytype.name;
            ViewBag.postcategoryid = categorytype.id;
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)//[Bind(Include = "id, title,chapter_no,searchingwords,Description,isactive,departmentid,postcategoryid")] Post post)
        {
            try
            {
                post.createdonutc = DateTime.UtcNow;
                post.updatedonutc = DateTime.UtcNow;
                post.userid = User.Identity.GetUserId();
                post.ipused = Request.UserHostAddress;
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", "adminpost", new { id= post.postcategoryid});
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
           
            ViewBag.departmentid = new SelectList(db.Department.Where(x => x.isactive == true), "id", "name");
            ViewBag.postcategoryid = new SelectList(db.PostCategory.Where(x => x.isactive == true), "id", "name");
            var adminpost = db.Post.Find(id);
            var categorytype = db.PostCategory.Find(adminpost.postcategoryid);
            ViewBag.postcategoryType = categorytype.name;
            ViewBag.postcategoryid = categorytype.id;
            return View(adminpost);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            try
            {
                // TODO: Add update logic here
                post.createdonutc = post.createdonutc;
                post.updatedonutc = DateTime.UtcNow;
                post.userid = User.Identity.GetUserId();
                post.ipused = Request.UserHostAddress;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "adminpost", new { id= post.postcategoryid});
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
