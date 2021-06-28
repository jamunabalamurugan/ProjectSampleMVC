using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationQuestionnare.Controllers
{
    public class ErrorHandlerController : Controller
    {
        
        public ActionResult NotFound()
        {
            return View();
        }
    }
}