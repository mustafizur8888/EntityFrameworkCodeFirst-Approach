using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class Animal1Controller : Controller
    {
        // GET: Animal1
        AnimalService service = new AnimalService();
        public ActionResult Index()
        {
            var viewAnimal = service.GetAnimals();
            return View(viewAnimal);
        }

        public ActionResult Details(int id)
        {
            ViewAnimal animal = service.GetAnimal(id);
            return View(animal);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Creat(Animal animal)
        {
            //Save
            bool save = service.Save(animal);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
           Animal animal =  service.GetDbAnimal(id);
            return View(animal);
        }

        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            //Save
            bool save = service.Update(animal);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            //Save
            bool save = service.Delete(animal);
            return RedirectToAction("Index");
        }
    }
}