﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHours.Controllers
{
    public class CocktailController : Controller
    {
        //
        // GET: /Cocktail/

        public ActionResult Index()
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
                HhDBO.Cocktail cocktail = BusinessManagement.Cocktail.GetCocktail(id.Value);
                return Json(cocktail, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //show all
                List<HhDBO.Cocktail> cocktails = BusinessManagement.Cocktail.GetListCocktail(10);
                return Json(cocktails, JsonRequestBehavior.AllowGet);
            }
        }

        //PUT - update
        [AcceptVerbs(HttpVerbs.Put)]
        public JsonResult WsRest(int id, HhDBO.Cocktail cocktail)
        {
            if (BusinessManagement.Cocktail.UpdateCocktail(cocktail))
            {
                HhDBO.Cocktail newCocktail = BusinessManagement.Cocktail.GetCocktail(id);
                return Json(newCocktail, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("wserror updating.", JsonRequestBehavior.AllowGet);
            }
        }

        //POST - create
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult WsRest(HhDBO.Cocktail cocktail)
        {
            //byte[] PostData = HttpContext.Request.BinaryRead(HttpContext.Request.ContentLength);
            //string postParams = Encoding.UTF8.GetString(PostData);

            if (cocktail != null)
            {
                if (cocktail.Id != 0)
                {
                    return WsRest(cocktail.Id, cocktail);
                }
                else
                {
                    HhDBO.Cocktail result = BusinessManagement.Cocktail.CreateCocktail(cocktail);
                    if (result == null)
                    {
                        return Json("wserror atcreation", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        cocktail = result;
                    }
                }

                return Json(cocktail, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json("wserror null cocktail", JsonRequestBehavior.AllowGet);
            }
        }

        //Delete - remove
        [AcceptVerbs(HttpVerbs.Delete)]
        public JsonResult WsRest(int id)
        {
            //do remove
            if (!BusinessManagement.Cocktail.DeleteCocktail(id))
            {
                return Json("wserror deleting.", JsonRequestBehavior.AllowGet);
            }

            if (BusinessManagement.Cocktail.GetCocktail(id) != null)
            {
                return Json("wserror after delete cocktail is still here.", JsonRequestBehavior.AllowGet);
            }

            return Json("wssuccess cocktail deleted.", JsonRequestBehavior.DenyGet);
        }

    }
}
