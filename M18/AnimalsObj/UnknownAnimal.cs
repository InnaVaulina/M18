using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public class UnknownAnimal : IAnimal
    {
        public UnknownAnimalParametres UAParametres { get; set; }

        public UnknownAnimal()
        {           
            UAParametres = new UnknownAnimalParametres("Чебурашка", "неизвестный вид питания", 0);
        }
        public UnknownAnimal(UnknownAnimalParametres ua)
        {
            UAParametres = ua;
        }
        public string Species { get { return UAParametres.uaSpecies; } }

        public string LiveState
        {
            get { return UAParametres.liveState; }
            set
            {
                switch (UAParametres.liveState)
                {
                    case "full":
                        if (value == "full") UAParametres.liveState = "full";
                        if (value == "hungry") UAParametres.liveState = "died";
                        break;
                    case "died": break;
                }
            }
        }

        public void Eat(Food food) 
        {
            LiveState = "hungry";
        }
    }


}
