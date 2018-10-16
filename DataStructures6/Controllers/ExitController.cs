using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures5.Controllers
{
    public class ExitController : Controller
    {
        // GET: Exit. This will take us to the byu home page and exit the Data Structures MVC
        public ActionResult Index()
        {
            return Redirect("https://www.byu.edu");
        }
    }
}