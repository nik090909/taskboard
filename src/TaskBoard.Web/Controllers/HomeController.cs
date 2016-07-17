using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            string result = "You are not autorized";
            if (User.Identity.IsAuthenticated)
            {
                result = $"Login: {User.Identity.Name}";
            }
            return result;
        }
    }
}