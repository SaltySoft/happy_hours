using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHours.Controllers
{
    public class IngredientController : Controller
    {
        //
        // GET: /Ingredient/

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
                HhDBO.Ingredient ingredient = BusinessManagement.Ingredient.GetIngredient(id.Value);
                return Json(ingredient, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //show all
                List<HhDBO.Ingredient> ingredients = BusinessManagement.Ingredient.GetListIngredient(10);
                return Json(ingredients, JsonRequestBehavior.AllowGet);
            }
        }

        //PUT - update
        [AcceptVerbs(HttpVerbs.Put)]
        public JsonResult WsRest(int id, HhDBO.Ingredient ingredient)
        {
            if (BusinessManagement.Ingredient.UpdateIngredient(ingredient))
            {
                HhDBO.Ingredient newIngredient = BusinessManagement.Ingredient.GetIngredient(id);
                return Json(newIngredient, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("wserror updating.", JsonRequestBehavior.AllowGet);
            }
        }

        //POST - create
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult WsRest(HhDBO.Ingredient ingredient)
        {
            //byte[] PostData = HttpContext.Request.BinaryRead(HttpContext.Request.ContentLength);
            //string postParams = Encoding.UTF8.GetString(PostData);

            if (ingredient != null)
            {
                if (ingredient.Id != 0)
                {
                    return WsRest(ingredient.Id, ingredient);
                }
                else
                {
                    HhDBO.Ingredient result = BusinessManagement.Ingredient.CreateIngredient(ingredient);
                    if (result == null)
                    {
                        return Json("wserror atcreation", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ingredient = result;
                    }
                }

                return Json(ingredient, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json("wserror null ingredient", JsonRequestBehavior.AllowGet);
            }
        }

        //Delete - remove
        [AcceptVerbs(HttpVerbs.Delete)]
        public JsonResult WsRest(int id)
        {
            //do remove
            if (!BusinessManagement.Ingredient.DeleteIngredient(id))
            {
                return Json("wserror deleting.", JsonRequestBehavior.AllowGet);
            }

            if (BusinessManagement.Ingredient.GetIngredient(id) != null)
            {
                return Json("wserror after delete ingredient is still here.", JsonRequestBehavior.AllowGet);
            }

            return Json("wssuccess ingredient deleted.", JsonRequestBehavior.DenyGet);
        }

    }
}
