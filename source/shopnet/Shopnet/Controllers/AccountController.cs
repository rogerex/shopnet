using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Shopnet.Models.Domain;
using System.Security.Cryptography;
using System.Text;
using Shopnet.Models;
using System.Data;
using Shopnet.ViewModels;

namespace Shopnet.Controllers
{
    public class AccountController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = ValidateUser(model.UserName, model.Password);
                if (user != null)
                {
                    // MigrateShoppingCart(model.UserName);

                    Session session = new Session()
                    {
                        UserID = user.UserID,
                        Init = DateTime.Now,
                        Status = 1
                    };
                    db.Sessions.AddObject(session);
                    db.SaveChanges();

                    Session["User"] = user;
                    Session["Session"] = session;

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "BasicPage");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private User ValidateUser(string userName, string password)
        {
            User user = null;
            string source = password;
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);
                if (VerifyMd5Hash(md5Hash, source, hash))
                {
                    IQueryable<User> users = db.Users.Where(u => u.Name == userName && u.Password == hash && u.Status == 1);
                    if (users.Count() == 1)
                        user = users.Single();
                }
            }
            return user;
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            if (Session["Session"] != null)
            {
                Session session = (Session)Session["Session"];
                session.End = DateTime.Now;
                session.Status = 0;
                db.Sessions.Attach(session);
                db.ObjectStateManager.ChangeObjectState(session, EntityState.Modified);
                db.SaveChanges();
                Session["Session"] = null;
                Session["User"] = null;
            }
            return RedirectToAction("Index", "BasicPage");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = CreateUser(model);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    // MigrateShoppingCart(model.UserName);
                    return RedirectToAction("Index", "BasicPage");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private MembershipCreateStatus CreateUser(RegisterModel model)
        {
            if (!db.Users.Where(u => u.Name == model.UserName).Any())
            {
                if (!db.Users.Where(u => u.Email == model.Email).Any())
                {
                    User user = new User();
                    user.Creation = DateTime.Now;
                    string source = model.Password;
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = GetMd5Hash(md5Hash, source);
                        if (VerifyMd5Hash(md5Hash, source, hash))
                        {
                            user.Name = model.UserName;
                            user.Email = model.Email;
                            user.Password = hash;
                            user.Status = 1;
                            db.Users.AddObject(user);
                            db.SaveChanges();
                            return MembershipCreateStatus.Success;
                        }
                        else
                        {
                            return MembershipCreateStatus.ProviderError;
                        }
                    }
                }
                else 
                {
                    return MembershipCreateStatus.DuplicateEmail;
                }
            }
            else
            {
                return MembershipCreateStatus.DuplicateUserName;
            }
        }

        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded = true;
                try
                {
                    if (ModelState.IsValid && model.OldPassword != null)
                    {
                        int id = ((Session)Session["Session"]).UserID;
                        User oldUser = db.Users.Single(u => u.UserID == id);

                        string source = model.OldPassword;
                        using (MD5 md5Hash = MD5.Create())
                        {
                            string hash = GetMd5Hash(md5Hash, source);
                            if (VerifyMd5Hash(md5Hash, source, hash))
                            {
                                if (hash == oldUser.Password)
                                {
                                    source = model.NewPassword;
                                    hash = GetMd5Hash(md5Hash, source);
                                    if (VerifyMd5Hash(md5Hash, source, hash))
                                    {
                                        oldUser.Password = hash;
                                        db.Users.Attach(oldUser);
                                        db.ObjectStateManager.ChangeObjectState(oldUser, EntityState.Modified);
                                        db.SaveChanges();
                                        changePasswordSucceeded = true;
                                    }   
                                }   
                            }       
                        }
                    }
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        //
        // GET: /Account/Details/

        public ViewResult Details()
        {
            int id = ((User)Session["User"]).UserID;
            User user = db.Users.Single(u => u.UserID == id);
            return View(new UserViewModel(user));
        }

        //
        // GET: /Account/AccountSummary

        [ChildActionOnly]
        public ActionResult AccountSummary()
        {
            ViewData["Session"] = Session["Session"] != null;
            if (Session["User"] != null) 
            {
                ViewData["UserID"] = ((User)Session["User"]).UserID;
            }
            return PartialView("AccountSummary");
        }

        //
        // GET: /Account/Register

        public ActionResult Edit()
        {
            string name = ((User)Session["User"]).Name;
            string email = ((User)Session["User"]).Email;
            return View(new EditModel() { UserName = name, Email = email});
        }

        //
        // POST: /Account/Edit

        [HttpPost]
        public ActionResult Edit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus editStatus = EditUser(model);

                if (editStatus == MembershipCreateStatus.Success)
                {
                    return RedirectToAction("Index", "BasicPage");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(editStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private MembershipCreateStatus EditUser(EditModel model)
        {
            int id = ((Session)Session["Session"]).UserID;
            User oldUser = db.Users.Single(u => u.UserID == id);
            if (oldUser.Name != model.UserName)
            {
                if (!db.Users.Where(u => u.UserID != id && u.Name == model.UserName).Any())
                {
                    oldUser.Name = model.UserName;
                }
                else
                {
                    return MembershipCreateStatus.DuplicateUserName;
                }
            }

            if (oldUser.Email != model.Email)
            {
                if (!db.Users.Where(u => u.UserID != id && u.Email == model.Email).Any())
                {
                    oldUser.Email = model.Email;
                }
                else
                {
                    return MembershipCreateStatus.DuplicateEmail;
                }
            }

            db.Users.Attach(oldUser);
            db.ObjectStateManager.ChangeObjectState(oldUser, EntityState.Modified);
            db.SaveChanges();
            return MembershipCreateStatus.Success;
        }

        #region Password Encriptation

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

        #endregion

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
