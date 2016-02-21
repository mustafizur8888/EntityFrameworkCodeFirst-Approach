using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ZooApp.Models;
using ZooApp.ViewModels;


namespace ZooApp.Services
{
    public class AnimalService
    {
        //create a _db object 
        private readonly ZooContext _db = new ZooContext();
        public List<ViewAnimal> GetAnimals()
        {

            //featch _db.animal data
            //pull all rows from table to ram
            List<Animal> animals = _db.Animals.ToList();
            //convert this data into view data
            List<ViewAnimal> viewAnimals = new List<ViewAnimal>();
            foreach (Animal animal in animals)
            {
                ViewAnimal viewAnimal = new ViewAnimal()
                {
                    Id = animal.Id,
                    Origin = animal.Origin,
                    Name = animal.Name
                };
                viewAnimals.Add(viewAnimal);
            }
            //return
            return viewAnimals;
        }

        public ViewAnimal GetAnimal(int id)
        {
            Animal animal = _db.Animals.Find(id);
            return new ViewAnimal()
            {
                Id = animal.Id,
                Name = animal.Name,
                Origin = animal.Origin
            };


        }

        public bool Save(Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
            return true;
        }

        public bool Update(Animal animal)
        {
            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
            return true;
        }
        public bool Delete(Animal animal)
        {
            Animal dbAnimal = _db.Animals.Find(animal.Id);
            _db.Animals.Remove(dbAnimal);
            _db.SaveChanges();

            return true;
        }

        public Animal GetDbAnimal(int id)
        {
            Animal animal = _db.Animals.Find(id);
            return animal;
        }
    }
}
