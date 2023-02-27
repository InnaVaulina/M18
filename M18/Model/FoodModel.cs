using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// пища на складе зоопарка
    /// </summary>
    public class FoodModel: IFoodModel
    {
        /// <summary>
        /// пища всех видов
        /// </summary>
        public FoodList FoodList { get; set; }

        /// <summary>
        /// изменилось количество пищи
        /// сообщить в презентер и eateAnimalModel
        /// </summary>
        public event FoodChangedHandler FoodNotify;

        /// <summary>
        /// название корма
        /// </summary>
        private string foodName { get;set; }

        /// <summary>
        /// количество корма
        /// </summary>
        private double foodCount { get; set; }
        public FoodModel(FoodList foodList) 
        {
            
            FoodList = foodList;
        }

        /// <summary>
        /// получить данные о порче корма
        /// </summary>
        /// <param name="f">корм</param>
        /// <param name="fc">количество</param>
        /// <exception cref="Exception"></exception>
        public void GetDateToRemove(string f, string fc) 
        {
            if (f == null || f == "") throw new Exception("Какая пища?");
            else this.foodName = f;
            if (double.TryParse(fc,out double c)) this.foodCount = c;
            else  throw new Exception("Сколько еды испорчено?");
        }
        
        /// <summary>
        /// получить данные о новом корме
        /// </summary>
        /// <param name="f"></param>
        /// <param name="fc"></param>
        /// <exception cref="Exception"></exception>
        public void GetDateToAdd(string f, string fc)
        {
            if (f == null || f == "") throw new Exception("Какая пища?");
            else this.foodName = f;
            if (double.TryParse(fc, out double c)) this.foodCount = c;
            else throw new Exception($"Сколько корма: {f}?");
        }

        /// <summary>
        /// добавление корма на склад
        /// </summary>
        /// <returns></returns>
        public string AddFood() 
        {
            string result = FoodList.AddFood(foodName, foodCount);
            FoodNotify?.Invoke();
            return result;
            
        }

        /// <summary>
        /// удаление корма со склада
        /// </summary>
        /// <returns></returns>
        public string RemoveFood() 
        {
            string result = FoodList.RemoveFood(foodName, foodCount);
            FoodNotify?.Invoke();
            return result;
        }
    }
}
