using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// поведение млекопитающего
    /// </summary>
    public class Mammal : IAnimal
    {
        public MammalParametres MParametres { get; set; }

        public Mammal(MammalParametres mammal)
        {
            MParametres = mammal;
        }

        public string Species { get { return MParametres.mSpecies; } }

        public string LiveState
        {
            get { return MParametres.liveState; }
            set
            {
                switch (MParametres.liveState)
                {
                    case "full":
                        if (value == "full") MParametres.liveState = "full";
                        if (value == "hungry") MParametres.liveState = "hungry";
                        break;
                    case "hungry":
                        if (value == "full") MParametres.liveState = "full";
                        if (value == "hungry") MParametres.liveState = "veryHungry";
                        break;
                    case "veryHungry":
                        if (value == "full") MParametres.liveState = "hungry";
                        if (value == "hungry") MParametres.liveState = "veryveryHungry";
                        break;
                    case "veryveryHungry":
                        if (value == "full") MParametres.liveState = "veryHungry";
                        if (value == "hungry") MParametres.liveState = "died";
                        break;
                    case "died": break;
                }
            }
        }
        public void Eat(Food food)
        {
            if (food.foodName == MParametres.mFood)
            {
                if (food.foodCount >= MParametres.mLimitDayFood)
                {
                    LiveState = "full";
                    food.foodCount -= MParametres.mLimitDayFood;
                }
                else LiveState = "hungry"; 
            }
            else LiveState = "hungry"; 
        }
     
    }


}
