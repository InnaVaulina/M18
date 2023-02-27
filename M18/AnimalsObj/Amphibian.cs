using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// поведение амфибии
    /// </summary>
    public class Amphibian : IAnimal
    {
        /// <summary>
        /// данные о земноводном
        /// </summary>
        public AmphibianParametres AParametres { get; set; }

        public Amphibian(AmphibianParametres amphibian)
        {
            AParametres = amphibian;
        }

        /// <summary>
        /// вид 
        /// </summary>
        public string Species { get { return AParametres.aSpecies; } }

        /// <summary>
        /// поведение - результат кормления тем или не тем кормом
        /// </summary>
        public string LiveState 
        {
            get { return AParametres.liveState; } 
            set 
            {
                switch (AParametres.liveState) 
                {
                    case "full":
                        if (value == "full") AParametres.liveState = "full";
                        if (value == "hungry") AParametres.liveState = "hungry";
                        break;
                    case "hungry": 
                        if (value == "full") AParametres.liveState = "full";
                        if (value == "hungry") AParametres.liveState = "veryHungry";
                        break;
                    case "veryHungry":
                        if (value == "full") AParametres.liveState = "full";
                        if (value == "hungry") AParametres.liveState = "veryveryHungry";
                        break;
                    case "veryveryHungry":
                        if (value == "full") AParametres.liveState = "full";
                        if (value == "hungry") AParametres.liveState = "died";
                        break;
                    case "died":break;
                }
            } 
        }

        /// <summary>
        /// кормление
        /// </summary>
        /// <param name="food"></param>
        public void Eat(Food food)
        {
            if (food.foodName == AParametres.aFood)
            {
                if (food.foodCount >= AParametres.aLimitDayFood) 
                { 
                    LiveState = "full"; 
                    food.foodCount -= AParametres.aLimitDayFood;
                }
                else LiveState = "hungry";
            }
            else LiveState = "hungry";
        }
    }





}
