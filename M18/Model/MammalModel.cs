using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// поселение млекопитающего в зоопарк
    /// ввод данных о млекопитающем
    /// </summary>
    public class MammalModel: IMammalModel
    {
        private MammalParametres mammal;
        private List<MammalParametres> mammalList;
        public List<MammalParametres> MammalList 
        {
            get { return mammalList; }
            set 
            { 
                mammalList = value;
                AnimalListChanged?.Invoke();
            }
        }


        public event AnimalAddHandler AnimalAddNotify;
        public event AnimalListChangedHandler AnimalListChanged;


        public MammalModel(List<MammalParametres> mammalList) 
        {
            this.MammalList = mammalList;
            
        }

        public void GetDateToAddMammal(string name, string food, string fcount, string speed) 
        {
            mammal = new MammalParametres();
            if (name == null || name == "") throw new Exception("Какое млекопитающее?");
            else this.mammal.mSpecies = name;
            if (food == null || food == "") throw new Exception($"Что {name} кушает?");
            else this.mammal.mFood = food;
            if (double.TryParse(fcount, out double c)) this.mammal.mLimitDayFood = c;
            else throw new Exception($"Сколько корма: {food} в день {name} кушает?");
            if (double.TryParse(speed, out double s)) this.mammal.earthSpeed = s;
            else throw new Exception($"С какой скоростью {name} бегает?");
            this.mammal.liveState = "full";
        }

        public string AddMammal() 
        {
            MammalList.Add(mammal);
            AnimalAddNotify?.Invoke("Mammal", mammal);
            return $"Новое млкопитающее {mammal.mSpecies} поселили в зоопарк.";
        }



    }
}
