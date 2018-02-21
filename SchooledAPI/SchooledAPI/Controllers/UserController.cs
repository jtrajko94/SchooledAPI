using SchooledAPI.Utilities;
using System;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult TestPost()
        {
            //TODO: Complete
            try
            {
                return Json(null);
            }
            catch (Exception err)
            {
                ServiceHelper.SendError(err);
                return Json(err);
            }
        }
    }
}