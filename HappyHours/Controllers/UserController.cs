﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HappyHours.Controllers
{
    public class UserController : Controller
    {

        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        //User Page View
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Users(int? Id)
        {
            return View();
        }

        //GET - show - index
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult WsRest(int? id)
        {
            if (id.HasValue)
            {
                //show
             
                HhDBO.User user = BusinessManagement.User.GetUser(id.Value).FirstOrDefault();
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //show all
                List<HhDBO.User> users = BusinessManagement.User.GetListUser(10);
                return Json(users, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CurrentUser()
        {

            
            string[] rolesArray;
            RolePrincipal r = (RolePrincipal)User;

            HhDBO.User user = BusinessManagement.User.GetUser(Int32.Parse(User.Identity.Name)).FirstOrDefault();
            if (user != null)
            {
                rolesArray = r.GetRoles();
                user.Roles = new List<string>();
                foreach (string role in rolesArray)
                {
                    user.Roles.Add(role);
                }
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Dictionary<string, string> dico = new Dictionary<string, string>();
                dico["status"] = "error";
                dico["reason"] = "disconnected";
                return Json(dico, JsonRequestBehavior.AllowGet);
            }
           
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Login(string username, string password)
        {
            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("failure", JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult Logout()
        {
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        //PUT - update
        [AcceptVerbs(HttpVerbs.Put)]
        public JsonResult WsRest(int id, HhDBO.User user)
        {
            if (BusinessManagement.User.UpdateUser(user))
            {
                HhDBO.User newUser = BusinessManagement.User.GetUser(id).FirstOrDefault();
                return Json(newUser, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("wserror updating.", JsonRequestBehavior.AllowGet);
            }
        }

        //POST - create
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult WsRest(HhDBO.User user)
        {
            //byte[] PostData = HttpContext.Request.BinaryRead(HttpContext.Request.ContentLength);
            //string postParams = Encoding.UTF8.GetString(PostData);

            if (user != null)
            {
                if (user.Id != 0)
                {
                    return WsRest(user.Id, user);
                }
                else
                {
                    HhDBO.User result = BusinessManagement.User.CreateUser(user);
                    if (result == null)
                    {
                        return Json("wserror atcreation", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        user = result;
                    }
                }

                return Json(user, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json("wserror null user", JsonRequestBehavior.AllowGet);
            }
        }

        //Delete - remove
        [AcceptVerbs(HttpVerbs.Delete)]
        public JsonResult WsRest(int id)
        {
            //do remove
            if (!BusinessManagement.User.DeleteUser(id))
            {
                return Json("wserror deleting.", JsonRequestBehavior.AllowGet);
            }

            if (BusinessManagement.User.GetUser(id).Count > 0)
            {
                return Json("wserror after delete user still here.", JsonRequestBehavior.AllowGet);
            }

            return Json("wssuccess user deleted.", JsonRequestBehavior.DenyGet);
        }


        public JsonResult Unauthorized()
        {
            Dictionary<string, string> dico = new Dictionary<string, string>();
            dico["status"] = "error";
            dico["message"] = "unsufficient_rights";

            return Json(dico, JsonRequestBehavior.AllowGet);
        }
    }
}
