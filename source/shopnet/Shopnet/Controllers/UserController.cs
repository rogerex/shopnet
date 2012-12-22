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

namespace Shopnet.Controllers
{ 
    public class UserController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /User/

        public ViewResult Index()
        {
            List<ViewUser> views = new List<ViewUser>();
            foreach (User user in db.Users.ToList())
            {
                views.Add(
                    new ViewUser(user)
                );
            }
            return View(views);
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
            User user = db.Users.Single(u => u.UserID == id);
            return View(new ViewUser(user));
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            ViewBag.Status = new SelectList((new ViewUser()).GetStatus(), "Value", "Text");
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
                    string hash = GetMd5Hash(md5Hash, source);
                    if (VerifyMd5Hash(md5Hash, source, hash))
                    {
                        user.Password = hash;
                        db.Users.AddObject(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Status = new SelectList((new ViewUser()).GetStatus(), "Value", "Text", user.Status);
                        return View(user);
                    }
                }
            }
            ViewBag.Status = new SelectList((new ViewUser()).GetStatus(), "Value", "Text", user.Status);
            return View(user);
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = db.Users.Single(u => u.UserID == id);
            ViewBag.Status = new SelectList((new ViewUser()).GetStatus(), "Value", "Text", user.Status);
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
                    string hash = GetMd5Hash(md5Hash, source);
                    if (VerifyMd5Hash(md5Hash, source, hash))
                    {
                        if (hash == oldUser.Password)
                        {
                            source = user.Password;
                            hash = GetMd5Hash(md5Hash, source);
                            user.Password = hash;
                            if (VerifyMd5Hash(md5Hash, source, hash))
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
                                ViewBag.Status = new SelectList((new ViewUser()).GetStatus(), "Value", "Text", user.Status);
                                return View(user);
                            }
                        }
                        else
                        {
                            ViewBag.Status = new SelectList((new ViewUser()).GetStatus(), "Value", "Text", user.Status);
                            return View(user);
                        }
                    }
                    else
                    {
                        ViewBag.Status = new SelectList((new ViewUser()).GetStatus(), "Value", "Text", user.Status);
                        return View(user);
                    }
                }
            }
            ViewBag.Status = new SelectList((new ViewUser()).GetStatus(), "Value", "Text", user.Status);
            return View(user);
        }

        //
        // GET: /User/Delete/5
 
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

        private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
            
        }

    }
}