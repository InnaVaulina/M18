using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// поселение птицы в зоопарк
    /// ввод данных о птице
    /// </summary>
    public class BirdModel : IBirdModel
    {
        private BirdParametres bird;

        private List<BirdParametres> birdList;
        public List<BirdParametres> BirdList 
        { 
            get { return birdList; }
            set 
            {
                birdList = value;
                AnimalListChanged?.Invoke();
            } 
        }

        public event AnimalAddHandler AnimalAddNotify;
        public event AnimalListChangedHandler AnimalListChanged;

        public BirdModel(List<BirdParametres> birdList)
        {
            this.BirdList = birdList;

        }

        public void GetDateToAddBird(string name, string food, string fcount, string speed)
        {
            bird = new BirdParametres();
            if (name == null || name == "") throw new Exception("Какая птица?");
            else this.bird.bSpecies = name;
            if (food == null || food == "") throw new Exception($"Что {name} кушает?");
            else this.bird.bFood = food;
            if (double.TryParse(fcount, out double c)) this.bird.bLimitDayFood = c;
            else throw new Exception($"Сколько корма: {food} в день {name} кушает?");
            if (double.TryParse(speed, out double s)) this.bird.airSpeed = s;
            else throw new Exception($"С какой скоростью {name} летает?");
            this.bird.liveState = "full";
        }

        public string AddBird()
        {
            BirdList.Add(bird);
            AnimalAddNotify?.Invoke("Bird", bird);
            return $"Новую птицу {bird.bSpecies} поселили в зоопарк.";
        }

    }
}
