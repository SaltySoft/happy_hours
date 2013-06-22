using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHours.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        public string Hello()
        {
            string res = "Yoyo  ";
            List<ServiceReferenceHappyHours.T_User> users = BusinessManagement.User.GetListUser(10);
            foreach (ServiceReferenceHappyHours.T_User user in users)
            {
                res += "username: " + user.username + " </br>";
                res += "email: " + user.email + " </br>";
                res += "password: " + user.password + " </br>";
                res += "admin: " + user.admin + " </br>";
                res += "-----------</br>";
            }
            return res;
        }

    }
}
