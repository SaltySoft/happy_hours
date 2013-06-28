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
        public JsonResult GetQuickSearchCocktails(string name, string ingredients, string difficulty, string quick, string alcohol)
        {
            HhDBO.SearchQuery searchQuery = new HhDBO.SearchQuery();
            searchQuery.Cocktail_name = name;
            searchQuery.Ingredients = ingredients;
            searchQuery.Difficulty = difficulty;
            searchQuery.Quick = quick;
            searchQuery.Alcohol = alcohol;

            List<HhDBO.Cocktail> cocktails = BusinessManagement.Cocktail.GetQuickSearchCocktails(searchQuery);
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
                if (current_user != null && current_user.Admin == 1)
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
            try
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
            catch (Exception)
            {
                Dictionary<string, object> dico = new Dictionary<string, object>();
                dico["status"] = "error";
                dico["message"] = "unknown_error";
                Response.StatusCode = 422;
                return Json(dico, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SendPicture(int id, HttpPostedFileBase picture)
        {
            string picture_path = Server.MapPath("~") + "Images\\Cocktails\\";

            if (picture != null)
            {
                string pictureRandomUrl = Path.GetFileNameWithoutExtension(picture.FileName)
                    + DateTime.Now.ToString("yyyyMMddHHmmssfff")
                    + Path.GetExtension(picture.FileName);

                picture.SaveAs(picture_path + pictureRandomUrl);
                HhDBO.Cocktail cocktail = BusinessManagement.Cocktail.GetCocktail(id);
                //if (System.IO.File.Exists(Server.MapPath("~") + cocktail.Picture_Url.Substring(1).Replace("/", "\\")))
                //{
                //    System.IO.File.Delete(Server.MapPath("~") + cocktail.Picture_Url.Substring(1).Replace("/", "\\"));
                //}
                cocktail.Picture_Url = "/Images/Cocktails/" + pictureRandomUrl;

                BusinessManagement.Cocktail.UpdateCocktail(cocktail);
                return Json(cocktail, JsonRequestBehavior.AllowGet);
            }

            return Json("wserror updating.", JsonRequestBehavior.AllowGet);
        }

        //POST - create
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "User")]
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
                    cocktail.Ingredients = new List<HhDBO.Ingredient>();
                    cocktail.Picture_Url = "";
                    cocktail.Recipe = "";
                    cocktail.Edited = 0;
                    cocktail.Duration = 1;
                    cocktail.Difficulty = 1;
                    cocktail.Description = "";
                    HhDBO.User user = BusinessManagement.User.GetUserByName(User.Identity.Name);
                    cocktail.Creator_Id = user.Id;
                    HhDBO.Cocktail result = null;
                    try
                    {
                        result = BusinessManagement.Cocktail.CreateCocktail(cocktail);
                    }
                    catch (HhDBO.Exceptions.AlreadyExistingException)
                    {
                        Dictionary<string, object> dico = new Dictionary<string, object>();
                        dico["status"] = "error";
                        dico["message"] = "already_existing";
                        Response.StatusCode = 422;

                        return Json(dico, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        Dictionary<string, object> dico = new Dictionary<string, object>();
                        dico["status"] = "error";

                        if (BusinessManagement.Cocktail.Validate(cocktail).Count > 0)
                        {
                            dico["message"] = "missing_information";
                            dico["data"] = BusinessManagement.Cocktail.Validate(cocktail);
                        }
                        else
                        {
                            dico["message"] = "unknown_error";
                        }
                        Response.StatusCode = 422;
                        return Json(dico, JsonRequestBehavior.AllowGet);
                    }


                    if (result == null)
                    {
                        Dictionary<string, object> dico = new Dictionary<string, object>();
                        dico["status"] = "error";


                        if (BusinessManagement.Cocktail.Validate(cocktail).Count > 0)
                        {
                            dico["message"] = "missing_information";
                            dico["data"] = BusinessManagement.Cocktail.Validate(cocktail);
                        }
                        else
                        {
                            dico["message"] = "unknown_error";
                        }
                        Response.StatusCode = 422;

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
