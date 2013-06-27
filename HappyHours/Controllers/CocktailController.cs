using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetRandomCocktail()
        {
            HhDBO.Cocktail cocktail = BusinessManagement.Cocktail.GetRandomCocktail();
            return Json(cocktail, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetQuickSearchCocktails(string name, string ingredients, string difficulty, string duration, string alcohol)
        {

            List<HhDBO.Cocktail> cocktails = BusinessManagement.Cocktail.GetListCocktail(10);
            return Json(cocktails, JsonRequestBehavior.AllowGet);
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
                
                List<HhDBO.Cocktail> cocktails;
                HhDBO.User current_user = BusinessManagement.User.GetUserByName(User.Identity.Name);
                if (current_user.Admin == 1)
                {
                    cocktails = BusinessManagement.Cocktail.GetListCocktailEdited(10, false);
                }
                else
                {
                    cocktails = BusinessManagement.Cocktail.GetListCocktail(10);
                }

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
        [Authorize(Roles = "Admin")]
        public JsonResult WsRest(HhDBO.Cocktail cocktail, HttpPostedFileBase picture)
        {
            //byte[] PostData = HttpContext.Request.BinaryRead(HttpContext.Request.ContentLength);
            //string postParams = Encoding.UTF8.GetString(PostData);

            string picture_path = Server.MapPath("~") + "Images\\Cocktails\\";

            if (cocktail != null)
            {
                if (cocktail.Id != 0)
                {
                    return WsRest(cocktail.Id, cocktail);
                }
                else
                {
                    if (picture != null)
                    {
                        string pictureRandomUrl = Path.GetFileNameWithoutExtension(picture.FileName) 
                            + DateTime.Now.ToString("yyyyMMddHHmmssfff")
                            + Path.GetExtension(picture.FileName);

                        picture.SaveAs(picture_path + pictureRandomUrl);
                        cocktail.Picture_Url = "/Images/Cocktails/" + pictureRandomUrl;
                    }
                    HhDBO.Cocktail result = BusinessManagement.Cocktail.CreateCocktail(cocktail);
                    if (result == null)
                    {
                        Dictionary<string, object> dico = new Dictionary<string, object>();
                        dico["status"] = "error";
                        dico["message"] = "invalid_data";
                        dico["data"] = BusinessManagement.Cocktail.Validate(cocktail);
                        return Json(dico, JsonRequestBehavior.AllowGet);
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
