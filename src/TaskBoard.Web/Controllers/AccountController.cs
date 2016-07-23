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

namespace TaskBoard.Web.Controllers
{
    public class AccountController : Controller
    {
        TaskDbContext db = new TaskDbContext();

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
                    var hash = GenerateHash(model.Password, user.PasswordSalt);
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
                    var salt = GenerateSalt();
                    var hash = GenerateHash(model.Password, salt);
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

        public string GenerateSalt()
        {
            var salt = new byte[64];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public string GenerateHash(string password, string salt)
        {
            var data = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash;
            using (SHA512 sha512 = new SHA512Managed())
            {
                hash = sha512.ComputeHash(data);
            }
            return Convert.ToBase64String(hash);
        }
    }
}