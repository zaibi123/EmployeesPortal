using EmployeesPortal.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmplyeesPortal.Core;
using EmployeesPortal.Web.Contexts;
using System.Configuration;
using System.IO;

using EmployeesPortal.Web.Helpers;

namespace EmployeesPortal.Web.Controllers
{
    [CustomAuthorizeAttribute(Roles = "Admin")]

    public class UsersAdminController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public UsersAdminController()
        {
        }

        public UsersAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        //
        // GET: /Users/
        public async Task<ActionResult> Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            return View(await UserManager.Users.ToListAsync());
        }


        #region user Add/edit/reset paswword
        //
        // GET: /Users/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);

            ViewBag.RoleNames = await UserManager.GetRolesAsync(user.Id);

            return View(user);
        }

        //
        // GET: /Users/Create
        public async Task<ActionResult> Create()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.countrylist = new SelectList(db.Country, "id", "nicename");
            ViewBag.statelist = new SelectList(db.State, "id", "name");
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
           
            return View();
        }

        //
        // POST: /Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, HttpPostedFileBase filename, params string[] selectedRoles)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserProfileImage/"))
                {
                    System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserProfileImage/");
                }
                if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserProfileImage/deleted"))
                {
                    System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserProfielImage/deleted");
                }
                var postedFile = Request.Files[0];
                if (postedFile.ContentLength > 0)
                {
                    if (postedFile.ContentType.ToLower() != "image/jpg" && postedFile.ContentType.ToLower() != "image/png" && postedFile.ContentType.ToLower() != "image/gif" && postedFile.ContentType.ToLower() != "image/jpeg")
                    {
                        ModelState.AddModelError("customer.profileimage", "Sorry, file format must be jpg or jpeg or png or gif");
                    }

                    if (ModelState.IsValid)
                    {
                        var imagapath = ConfigurationManager.AppSettings["userimagepath"].ToString();
                        var deletedimagepath = ConfigurationManager.AppSettings["deleteduserimagepath"].ToString();
                        var oldfile = user.ProfileImage;
                        var oldfileExt = Path.GetExtension(oldfile);
                        var fileExt = Path.GetExtension(postedFile.FileName);
                        var oldfileName = user.ProfileImage;
                        var oldpath = Path.Combine(Server.MapPath(imagapath) + oldfileName + oldfileExt);
                        var fileName = user.Id;
                        var deleltedfielname = fileName + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        var path = Path.Combine(Server.MapPath(imagapath) + fileName + fileExt);
                        deletedimagepath = Path.Combine(Server.MapPath(deletedimagepath + deleltedfielname + fileExt));
                        if (System.IO.File.Exists(oldpath)) System.IO.File.Move(oldpath, deletedimagepath);
                        postedFile.SaveAs(path);
                        user.ProfileImage = fileName + fileExt;
                    }
                }
                user = new ApplicationUser { UserName = userViewModel.Email, Email = userViewModel.Email, FirstName = userViewModel.FirstName, LastName = userViewModel.LastName, Address = userViewModel.Address, City = userViewModel.City, StateId = userViewModel.StateId, CountryId = userViewModel.CountryId,  Zip = userViewModel.Zip, Phone = userViewModel.Phone, Mobile = userViewModel.Mobile, isactive = true };
                var adminresult = await UserManager.CreateAsync(user, userViewModel.Password);

                //Add User to the selected Roles 
                if (adminresult.Succeeded)
                {
                    
                    if (selectedRoles != null)
                    {
                        var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.countrylist = new SelectList(db.Country, "id", "nicename");
                    ViewBag.statelist = new SelectList(db.State, "id", "name");
                    ModelState.AddModelError("", adminresult.Errors.First());
                    ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
                
                    return View();

                }
                return RedirectToAction("Index");
            }
            ViewBag.countrylist = new SelectList(db.Country, "id", "nicename");
            ViewBag.statelist = new SelectList(db.State, "id", "name");
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
           
            return View();
        }

        //
        // GET: /Users/Edit/1
        public async Task<ActionResult> Edit(string id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userRoles = await UserManager.GetRolesAsync(user.Id);
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ViewBag.countrylist = new SelectList(db.Country, "id", "nicename", user.CountryId);
            ViewBag.statelist = new SelectList(db.State, "id", "name", user.StateId);
       
            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                StateId = user.StateId,
                CountryId = user.CountryId,
                
                Zip = user.Zip,
                Phone = user.Phone,
                Mobile = user.Mobile,
               
                isactive = user.isactive,
                ProfileImage = user.ProfileImage,
                RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                }),
               
            });
        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Email,Id,FirstName,LastName,Address,City,StateId,CountryId,Levelid,Zip,Phone,Mobile,Designation,ProfileImage,Skypeid,isactive")] EditUserViewModel editUser, HttpPostedFileBase filename, params string[] selectedRole)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.UserName = editUser.Email;
                user.Email = editUser.Email;
                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.Address = editUser.Address;
                user.City = editUser.City;
                user.StateId = editUser.StateId;
                user.CountryId = editUser.CountryId;
                
                user.Zip = editUser.Zip;
                user.Phone = editUser.Phone;
                user.Mobile = editUser.Mobile;
                
                
                user.isactive = editUser.isactive;
                if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserProfileImage/"))
                {
                    System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserProfileImage/");
                }
                if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserProfileImage/deleted"))
                {
                    System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserProfileImage/deleted");
                }
                if (Request.Files.Count > 0)
                {
                    var postedFile = Request.Files[0];
                    if (postedFile.ContentLength > 0)
                    {
                        if (postedFile.ContentType.ToLower() != "image/jpg" && postedFile.ContentType.ToLower() != "image/png" && postedFile.ContentType.ToLower() != "image/gif" && postedFile.ContentType.ToLower() != "image/jpeg")
                        {
                            ModelState.AddModelError("user.ProfileImage", "Sorry, file format must be jpg or jpeg or png or gif");
                        }

                        if (ModelState.IsValid)
                        {
                            var imagapath = ConfigurationManager.AppSettings["userimagepath"].ToString();
                            var deletedimagepath = ConfigurationManager.AppSettings["deleteduserimagepath"].ToString();
                            var oldfile = user.ProfileImage;
                            var oldfileExt = Path.GetExtension(oldfile);
                            var fileExt = Path.GetExtension(postedFile.FileName);
                            var oldfileName = user.ProfileImage;
                            var oldpath = Path.Combine(Server.MapPath(imagapath) + oldfileName + oldfileExt);
                            var fileName = user.Id;
                            var deleltedfielname = fileName + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                            var path = Path.Combine(Server.MapPath(imagapath) + fileName + fileExt);
                            deletedimagepath = Path.Combine(Server.MapPath(deletedimagepath + deleltedfielname + fileExt));
                            if (System.IO.File.Exists(oldpath)) System.IO.File.Move(oldpath, deletedimagepath);
                            postedFile.SaveAs(path);
                            user.ProfileImage = fileName + fileExt;
                        }
                    }
                }
                var updateuser = await UserManager.UpdateAsync(user);

                string ismyprofile = Request.Form["myprofileid"].ToString();
                if (ismyprofile == "yes")
                {

                    return RedirectToAction("myprofile", "home");
                }
                else
                {
                    var userRoles = await UserManager.GetRolesAsync(user.Id);

                    selectedRole = selectedRole ?? new string[] { };

                    var result = await UserManager.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray<string>());

                    if (!result.Succeeded)
                    {
                        ViewBag.countrylist = new SelectList(db.Country, "id", "nicename");
                        ViewBag.statelist = new SelectList(db.State, "id", "name");
                        ModelState.AddModelError("", result.Errors.First());
                        return View();
                    }
                    result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray<string>());

                    if (!result.Succeeded)
                    {
                        ViewBag.countrylist = new SelectList(db.Country, "id", "nicename");
                        ViewBag.statelist = new SelectList(db.State, "id", "name");
                      

                        ModelState.AddModelError("", result.Errors.First());
                        return View();
                    }
                    if (result.Succeeded)
                    {
                       
                        
                    }
                    return RedirectToAction("Index");
                }
            }
            string Ismyprofile = Request.Form["myprofileid"].ToString();
            if (Ismyprofile == "yes")
            {
                ModelState.AddModelError("", "All Fields with * are required.");
                return RedirectToAction("myprofile", "home");
            }
            else
            {
                ViewBag.countrylist = new SelectList(db.Country, "id", "nicename");
                ViewBag.statelist = new SelectList(db.State, "id", "name");
              
                ModelState.AddModelError("", "Something failed.");
                return View();
            }
        }

        //
        // GET: /Users/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = await UserManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: /UserAdmin/ResetPassword
        public ActionResult ResetPassword(string id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.poscategories = db.PostCategory.Where(x => x.isactive == true).OrderBy(x => x.id).ToList();
            ResetUserPasswordViewModel model = new ResetUserPasswordViewModel() { Id = id };
            return View(model);
        }

        //
        // POST: /UserAdmin/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetUserPasswordViewModel model)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("login", "account");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var removePassword = UserManager.RemovePassword(model.Id);
            if (removePassword.Succeeded)
            {
                //Removed Password Success
                var validPass = await UserManager.PasswordValidator.ValidateAsync(model.NewPassword);
                if (validPass.Succeeded)
                {
                    var AddPassword = UserManager.AddPassword(model.Id, model.NewPassword);
                    if (AddPassword.Succeeded)
                    {
                        return View("PasswordResetConfirm");
                    }
                }
                else
                {
                    string errors = string.Empty;
                    foreach (var items in validPass.Errors)
                    {
                        errors += items.ToString();
                    }
                    ModelState.AddModelError("", errors);
                    return View(model);
                }
               
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        #endregion
    }
}
