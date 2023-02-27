using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// корм
    /// </summary>
    public class Food
    {
        public string foodName { get; set; }
        public double foodCount { get; set; }

        public Food() 
        {
            foodName = "";
            foodCount = 0;
        }
        public Food(string fN, double fC) 
        {
            foodName = fN;
            foodCount = fC;
        }

    }

    /// <summary>
    /// склад с кормом
    /// </summary>
    public class FoodList 
    {
        public List<Food> foodList { get; set; }

        public FoodList() 
        {
            foodList = new List<Food>();
        }

        public string AddFood(string foodName, double foodCount) 
        {
            string result = $"";
            double fc = foodCount;
            foreach(var food in foodList) 
            {
                if (foodName == food.foodName) 
                { 
                    food.foodCount += fc;
                    result = $"Добавлено {fc} корма: {foodName}";
                    fc = 0;                   
                    break;
                }
            }
            if(fc > 0) 
            {
                foodList.Add(new Food(foodName, foodCount));
                result = $"Добавлен новый корм: {foodName}";
            }
            return result;             
        }

        public string RemoveFood(string foodName, double foodCount) 
        {
            string result = $"{foodName} нет в запасах";
            for (int i = 0; i< foodList.Count; i++)
            {
                if (foodName == foodList[i].foodName)
                {
                    if (foodCount < foodList[i].foodCount)
                    {
                        foodList[i].foodCount -= foodCount;
                        result = $"выброшено {foodCount} {foodName}";
                    }
                    else 
                    { 
                        foodList.Remove(foodList[i]);
                        result = $"выброшено полностью {foodName}";
                    }
                    break;
                }
            }
            return result;
        }
    }


}
