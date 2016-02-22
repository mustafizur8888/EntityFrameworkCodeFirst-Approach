using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        private readonly ZooContext _db = new ZooContext();
        public List<ViewFood> GetAll()
        {
            var list = _db.Foods.ToList();
            var viewFoods = new List<ViewFood>();
            foreach (var l in list)
            {
                var viewFood = new ViewFood(l);
                
                viewFoods.Add(viewFood);
            }
            //return
            return viewFoods;
        }



        public ViewFood Get(int id)
        {
            Food food = _db.Foods.Find(id);
            return new ViewFood(food);



        }

        public bool Save(Food food)
        {
            _db.Foods.Add(food);
            _db.SaveChanges();
            return true;
        }

        public bool Update(Food food)
        {
            _db.Entry(food).State = EntityState.Modified;
            _db.SaveChanges();
            return true;
        }
        public bool Delete(Food food)
        {
            Food dbfood = _db.Foods.Find(food.Id);
            _db.Foods.Remove(dbfood);
            _db.SaveChanges();

            return true;
        }

        public Food GetDbModel(int id)
        {
            Food food = _db.Foods.Find(id);
            return food;
        }

    }
}
