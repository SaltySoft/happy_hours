using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHours.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public JsonResult Index(int? id)
        {
            if (id.HasValue)
            {
                List<HhDBO.User> users = BusinessManagement.User.GetUser(id.Value);
                var data = users;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<HhDBO.User> users = BusinessManagement.User.GetListUser(10);
                var data = users;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
