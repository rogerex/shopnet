using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;
using Shopnet.ViewModels;
using System.Security.Cryptography;
using System.Text;
using Shopnet.Models.Domain;
using Shopnet.Controllers.Attributes;

namespace Shopnet.Controllers
{
    [Permission(Title = "User", Description = "User Controller")]
    public class UserController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /User/

        [UserAccess(Title = "User List", Description = "Access to User List")]
        public ViewResult Index()
        {
            List<UserViewModel> views = new List<UserViewModel>();
            foreach (User user in db.Users.ToList())
            {
                views.Add(
                    new UserViewModel(user)
                );
            }
            return View(views);
        }

        //
        // GET: /User/Details/5

        [UserAccess(Title = "User Details", Description = "Access to User Details")]
        public ViewResult Details(int id)
        {
            User user = db.Users.Single(u => u.UserID == id);
            return View(new UserViewModel(user));
        }

        //
        // GET: /User/Create

        [UserAccess(Title = "User Create", Description = "Access to User Create", RestrictAccess = true)]
        public ActionResult Create()
        {
            ViewBag.Status = new SelectList((new UserViewModel()).GetStatus(), "Value", "Text");
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Creation = DateTime.Now;
                string source = user.Password;
                using (MD5 md5Hash = MD5.Create())
                {
                    Encryptor enc = new Encryptor();
                    string hash = enc.GetMd5Hash(md5Hash, source);
                    if (enc.VerifyMd5Hash(md5Hash, source, hash))
                    {
                        user.Password = hash;
                        db.Users.AddObject(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Status = new SelectList((new UserViewModel()).GetStatus(), "Value", "Text", user.Status);
                        return View(user);
                    }
                }
            }
            ViewBag.Status = new SelectList((new UserViewModel()).GetStatus(), "Value", "Text", user.Status);
            return View(user);
        }

        //
        // GET: /User/AddRole/5

        [UserAccess(Title = "Add role to user", Description = "Enable grant roles to user")]
        public ActionResult AddRole(User user)
        {
            IEnumerable<Role> myRoles = db.Roles.Where(r => r.Usuarios.Any(u => u.UserID == user.UserID));
            var model = new AssignRolesToUserViewModel(user, myRoles, db.Roles);
            return View(model);
        }

        //
        // POST: /User/AddRole/5

        [HttpPost]
        public ActionResult AddRole(int id_user, FormCollection postedForm)
        {
            User user = db.Users.Include("Roles").Single(u => u.UserID == id_user);
            db.Users.Attach(user);

            RemoveAllItems(user);

            foreach (var item in db.Roles.ToList())
            {
                if (postedForm[item.Name].ToString().Contains("true"))
                {
                    user.Roles.Add(item);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void RemoveAllItems(User user)
        {
            foreach (var item in user.Roles.ToList())
            {
                user.Roles.Remove(item);
            }

            db.SaveChanges();
        }

        //
        // GET: /User/Edit/5

        [UserAccess(Title = "User edit", Description = "Access to User edit", RestrictAccess = true)]
        public ActionResult Edit(int id)
        {
            User user = db.Users.Single(u => u.UserID == id);
            ViewBag.Status = new SelectList((new UserViewModel()).GetStatus(), "Value", "Text", user.Status);
            user.Password = String.Empty;
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid && user.OldPassword != null)
            {
                User oldUser = db.Users.Single(u => u.UserID == user.UserID);
                
                string source = user.OldPassword;
                using (MD5 md5Hash = MD5.Create())
                {
                    Encryptor enc = new Encryptor();
                    string hash = enc.GetMd5Hash(md5Hash, source);
                    if (enc.VerifyMd5Hash(md5Hash, source, hash))
                    {
                        if (hash == oldUser.Password)
                        {
                            source = user.Password;
                            hash = enc.GetMd5Hash(md5Hash, source);
                            user.Password = hash;
                            if (enc.VerifyMd5Hash(md5Hash, source, hash))
                            {
                                oldUser.Name = user.Name;
                                oldUser.Email = user.Email;
                                oldUser.Password = hash;
                                oldUser.Status = user.Status;
                                db.Users.Attach(oldUser);
                                db.ObjectStateManager.ChangeObjectState(oldUser, EntityState.Modified);
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.Status = new SelectList((new UserViewModel()).GetStatus(), "Value", "Text", user.Status);
                                return View(user);
                            }
                        }
                        else
                        {
                            ViewBag.Status = new SelectList((new UserViewModel()).GetStatus(), "Value", "Text", user.Status);
                            return View(user);
                        }
                    }
                    else
                    {
                        ViewBag.Status = new SelectList((new UserViewModel()).GetStatus(), "Value", "Text", user.Status);
                        return View(user);
                    }
                }
            }
            ViewBag.Status = new SelectList((new UserViewModel()).GetStatus(), "Value", "Text", user.Status);
            return View(user);
        }

        //
        // GET: /User/Delete/5

        [UserAccess(Title = "User Delete", Description = "Access to User Delete", RestrictAccess = true)]
        public ActionResult Delete(int id)
        {
            User user = db.Users.Single(u => u.UserID == id);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            User user = db.Users.Single(u => u.UserID == id);
            db.Users.DeleteObject(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}