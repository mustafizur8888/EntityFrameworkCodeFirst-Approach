﻿using System.Web.Mvc;
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
            var viewAnimal = service.GetAll();
            return View(viewAnimal);
        }

        public ActionResult Details(int id)
        {
            ViewAnimal animal = service.Get(id);
            return View(animal);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(Animal animal)
        {
            try
            {
                // TODO: Add insert logic here
                var save = service.Save(animal);
                if (save)
                {
                    return RedirectToAction("Index");
                }
                return View(animal);

            }
            catch
            {
                return View(animal);
            }
        }
       
        [HttpGet]
        public ActionResult Edit(int id)
        {
           Animal animal =  service.GetDbModel(id);
            return View(animal);
        }

        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            //Save
            service.Update(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
           
            return View( service.GetDbModel(id));
        }

        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            //Save
            service.Delete(animal);
            return RedirectToAction("Index");
        }
    }
}