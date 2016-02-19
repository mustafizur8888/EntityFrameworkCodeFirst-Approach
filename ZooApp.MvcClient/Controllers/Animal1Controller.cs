using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Services;

namespace ZooApp.MvcClient.Controllers
{
    public class Animal1Controller : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            AnimalService service = new AnimalService();
            ;
            var viewAnimal = service.GetAnimals();
            return View(viewAnimal);
        }
    }
}