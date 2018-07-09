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
using System.IO;

namespace EmployeesPortal.Web.Controllers
{
    public class UploadImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UploadImages
        public ActionResult Index()
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(db.UploadImages.ToList());
        }

        // GET: UploadImages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UploadImages/Create
        public ActionResult Create()
        {
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View();
        }

        // POST: UploadImages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UploadImagesVM UploadImages)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UploadImages UploadImage = new UploadImages();

                    // Verify if resume has been uploaded.
                    if (UploadImages.images.HasFile())
                    {
                        // check file extension
                        string extension = System.IO.Path.GetExtension(UploadImages.images.FileName).ToLower();

                        if (extension != ".png" && extension != ".jpg" && extension != ".jpeg" && extension!= ".gif")
                        {
                            ModelState.AddModelError("resume", "Sorry, file format is invalid. Supported file extensions: jpg, jpeg, png, gif");
                            return View(UploadImages);
                        }

                        //************** Save file **************************.

                        // extract only the filename
                        var fileName = Path.GetFileName(UploadImages.images.FileName);

                        // store the file inside ~/App_Data/uploads folder
                        var path = Path.Combine(Server.MapPath("~/Uploads/PostImages"), fileName + DateTime.Now.ToString("yyyyMMddHHmmss"));

                        try
                        {
                            if (System.IO.File.Exists(path))
                                System.IO.File.Delete(path);

                            UploadImages.images.SaveAs(path);

                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("Resume", "Can't save file to disk.");
                        }

                        UploadImage.images= fileName;
                    }
                    else
                    {
                        UploadImage.images = "";
                    }

                    UploadImage.createdonutc = DateTime.UtcNow;
                    UploadImage.updatedonutc = DateTime.UtcNow;
                    UploadImage.userid = User.Identity.GetUserId();
                    UploadImage.ipused = Request.UserHostAddress;
                    db.UploadImages.Add(UploadImage);
                    db.SaveChanges();

                }
                    // TODO: Add insert logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UploadImages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UploadImages/Edit/5
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

        // GET: UploadImages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UploadImages/Delete/5
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
