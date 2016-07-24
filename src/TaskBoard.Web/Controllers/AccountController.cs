using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using TaskBoard.Web.Infrastructure.DataAccess;
using TaskBoard.Web.Models.ViewModels;
using TaskBoard.Web.Infrastructure.Domain;
using TaskBoard.Web.Infrastructure.Helpers;

namespace TaskBoard.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        readonly TaskDbContext db = new TaskDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var user = db.Users.FirstOrDefault(u => u.Login == model.Username);


                if (user != null)
                {
                    var hash = CryptographyHelper.GenerateHash(model.Password, user.PasswordSalt);
                    if (hash == user.PasswordHash)
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Name == model.Username);

                if (user == null)
                {
                    var salt = CryptographyHelper.GenerateSalt();
                    var hash = CryptographyHelper.GenerateHash(model.Password, salt);
                    db.Users.Add(new User { Login = model.Username, PasswordHash = hash, PasswordSalt = salt });
                    db.SaveChanges();

                    user = db.Users.Where(u => u.Name == model.Username && u.Password == model.Password).FirstOrDefault();


                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username already exist");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}