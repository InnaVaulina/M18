using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// поведение птицы
    /// </summary>
    public class Bird : IAnimal
    {
        public BirdParametres BParametres { get; set; }

        public Bird(BirdParametres bird)
        {
            BParametres = bird;
        }
        public string Species { get { return BParametres.bSpecies; } }

        public string LiveState
        {
            get { return BParametres.liveState; }
            set
            {
                switch (BParametres.liveState)
                {
                    case "full":
                        if (value == "full") BParametres.liveState = "full";
                        if (value == "hungry") BParametres.liveState = "hungry";
                        break;
                    case "hungry":
                        if (value == "full") BParametres.liveState = "full";
                        if (value == "hungry") BParametres.liveState = "veryHungry";
                        break;
                    case "veryHungry":
                        if (value == "full") BParametres.liveState = "full";
                        if (value == "hungry") BParametres.liveState = "died";
                        break;
                    case "died": break;
                }
            }
        }
        public void Eat(Food food)
        {
            if (food.foodName == BParametres.bFood)
            {
                if (food.foodCount >= BParametres.bLimitDayFood)
                { 
                    LiveState = "full"; 
                    food.foodCount -= BParametres.bLimitDayFood;
                }
                else LiveState = "hungry";
            }
            else LiveState = "hungry";
        }

    }



}
