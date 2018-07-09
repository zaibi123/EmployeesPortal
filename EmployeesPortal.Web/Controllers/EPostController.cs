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
        public ActionResult Index(int id)
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(db.Post.Where(x => x.isactive == true && x.postcategoryid == id).ToList());
        }

        // GET: EmpPost/Details/5
        public ActionResult Details(int id)
        {
            PostCommentVM postcomment = new PostCommentVM();
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            postcomment.commentlist = db.Comments.Where(x=>x.postid== id).ToList();
            postcomment.Post= db.Post.Find(id);
            return View(postcomment);
        }
        public ActionResult savecomment(long id, string comment)
        {
            Comments Comments = new Comments();
            Comments.comment = comment;
            Comments.postid = id;
            Comments.commentDate = System.DateTime.UtcNow;
            Comments.createdonutc = System.DateTime.UtcNow;
            Comments.updatedonutc = System.DateTime.UtcNow;
            Comments.ipused = Request.UserHostAddress;
            Comments.userid = User.Identity.GetUserId();
            Comments.commentbyUserId = User.Identity.GetUserId();
            Comments.commentbyUserName = User.Identity.GetUserName();
            db.Comments.Add(Comments);
            db.SaveChanges();
            return Json(new {success= true, commentText=comment, commentBy= User.Identity.GetUserName() });
        }

        public ActionResult RegisterReadPost(long postid, int isread, int isunderstand)
        {
            PostDetail pdetail = new PostDetail();

            var post = db.Post.Find(postid);

            if (post != null) {
                pdetail.postid = post.id;
                pdetail.departmentid = post.departmentid;
                pdetail.postcategoryid = post.postcategoryid;
                pdetail.employeeid = User.Identity.GetUserId();
               // pdetail.isread = isread;
               // pdetail.isunderstand = isunderstand;
                pdetail.createdonutc = System.DateTime.UtcNow;
                pdetail.updatedonutc = System.DateTime.UtcNow;
                pdetail.ipused = Request.UserHostAddress;
                pdetail.userid = User.Identity.GetUserId();
                pdetail.lastvisitdate = System.DateTime.UtcNow;
                pdetail.firstvisitdate = System.DateTime.UtcNow;
                db.PostDetail.Add(pdetail);
                db.SaveChanges();
            }

            return Json(new { success = true });

        }

        public ActionResult PostClickSave(long id)
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            PostClickCount postclick = new PostClickCount();
            postclick.postid = id;
            postclick.postclickby = User.Identity.GetUserId().ToString();
            postclick.postclickdate = System.DateTime.UtcNow.ToString();
            postclick.createdonutc = System.DateTime.UtcNow;
            postclick.updatedonutc = System.DateTime.UtcNow;
            postclick.ipused = Request.UserHostAddress;
            postclick.userid = User.Identity.GetUserId();
            db.PostClickCount.Add(postclick);
            db.SaveChanges();
            return RedirectToAction("Details","epost",new { id=id});
            //return Json(new { success = true, successtext="click view added."});
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
