using System;
using System.Collections.Generic;
using System.Linq;
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
                var user = db.Users.FirstOrDefault(u => u.Name == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    return RedirectToAction("Index", "Home");
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


                    db.Users.Add(new User { Name = model.Username, Password = model.Password });
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