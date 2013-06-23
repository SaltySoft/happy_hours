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

        public string Test()
        {
            string res = "Yoyo  ";
            String test = BusinessManagement.User.Test();
            res += test;
            return res;
        }

        public string Hello()
        {
            string res = "Yoyo  ";
            List<HhDataLayer.DBO.User> users = BusinessManagement.User.GetListUser(10);
            foreach (HhDataLayer.DBO.User user in users)
            {
                res += "username: " + user.Username + " </br>";
                res += "email: " + user.Email + " </br>";
                res += "password: " + user.Password + " </br>";
                res += "admin: " + user.Admin + " </br>";
                res += "-----------</br>";
            }
            return res;
        }

        public ActionResult TestJsonContent()
        {
             List<HhDataLayer.DBO.User> users = BusinessManagement.User.GetListUser(10);

            ViewBag.Message = Json(users, "text/x-json");

            return View("TestJson");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TestJsonContent(int numDay)
        {
            List<double> list = new List<double>();

            for (double d = 0; d < numDay; d++)
                list.Add(d + .5);

            return Json(list, "text/x-json");
        }
    }
}
