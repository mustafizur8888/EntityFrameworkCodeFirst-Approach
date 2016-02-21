using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        FoodService service = new FoodService();
        public ActionResult Index()
        {
            var viewFoods = service.GetAll();
            return View(viewFoods);
        }

        // GET: Food/Details/5
        public ActionResult Details(int id)
        {

            ViewFood food = service.Get(id);
            return View(food);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult Create(Food food)
        {
            try
            {
                // TODO: Add insert logic here
                var save = service.Save(food);
                if (save)
                {
                    return RedirectToAction("Index");
                }
                return View(food);

            }
            catch
            {
                return View(food);
            }
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int id)
        {
            Food food = service.GetDbModel(id);
            return View(food);
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult Edit(Food food)
        {
            try
            {
                // TODO: Add update logic here
                bool save = service.Update(food);
                if (save)
                {
                    return RedirectToAction("Index");
                }
                return View(food);

            }
            catch
            {
                return View(food);
            }
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int id)
        {
           Food food =  service.GetDbModel(id);
           return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult Delete(Food food)
        {
            try
            {
                var save = service.Delete(food);
                if (save)
                {
                    return RedirectToAction("Index");
                }
                return View(food);

            }
            catch
            {
                return View(food);
            }
        }
    }
}
