using AnimalFood = ZooApp.Models.AnimalFood;

namespace ZooApp.ViewModels
{
    public class ViewFoodTotal
    {
        public ViewFoodTotal(AnimalFood animalFood)
        {
            FoodName = animalFood.Food.Name;
            FoodPrice = animalFood.Food.Price;
            TotalQuantity = animalFood.Animal.Quantity * animalFood.Quantity;
            TotalPrice = animalFood.Food.Price * TotalQuantity;
        }

        public double TotalPrice {get;private set; }

        public double TotalQuantity { get; set; }

        public double FoodPrice { get; set; }

        public string FoodName { get; set; }
    }
}
