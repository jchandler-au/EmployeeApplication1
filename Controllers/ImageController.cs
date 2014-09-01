using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplication1.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index(byte[] imageData)
        {
            return File(imageData, "image/gif"); // This is not working
        }
    }
}