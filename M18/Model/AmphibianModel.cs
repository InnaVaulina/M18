using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// поселение земноводного в зоопарк
    /// ввод данных о земноводном
    /// </summary>
    public class AmphibianModel : IAmphibianModel
    {
        /// <summary>
        /// животное
        /// </summary>
        private AmphibianParametres amphibian;

        private List<AmphibianParametres> amphibianList;

        /// <summary>
        /// список животных
        /// в случае обновления списка, нужно сообщить в презентер
        /// </summary>
        public List<AmphibianParametres> AmphibianList 
        {
            get { return amphibianList; }
            set 
            {
                amphibianList = value;
                AnimalListChanged?.Invoke();
            } 
        }

        /// <summary>
        /// добавление животного в список
        /// </summary>
        public event AnimalAddHandler AnimalAddNotify;

        /// <summary>
        /// событие: изменение данных о списке животных
        /// </summary>
        public event AnimalListChangedHandler AnimalListChanged;


        public AmphibianModel(List<AmphibianParametres> aList)
        {
            this.AmphibianList = aList;

        }

        /// <summary>
        /// получение данных о животном
        /// </summary>
        /// <param name="name"></param>
        /// <param name="food"></param>
        /// <param name="fcount"></param>
        /// <param name="speed"></param>
        /// <exception cref="Exception"></exception>
        public void GetDateToAddAmphibian(string name, string food, string fcount, string speed)
        {
            amphibian = new AmphibianParametres();
            if (name == null || name == "") throw new Exception("Какое земноводное?");
            else this.amphibian.aSpecies = name;
            if (food == null || food == "") throw new Exception($"Что {name} кушает?");
            else this.amphibian.aFood = food;
            if (double.TryParse(fcount, out double c)) this.amphibian.aLimitDayFood = c;
            else throw new Exception($"Сколько корма: {food} в день {name} кушает?");
            if (double.TryParse(speed, out double s)) this.amphibian.waterSpeed = s;
            else throw new Exception($"С какой скоростью {name} плавает?");
            this.amphibian.liveState = "full";
        }

        /// <summary>
        /// поселение животного в зоопарк
        /// сообщение eateanimalModel данных о животном
        /// </summary>
        /// <returns></returns>
        public string AddAmphibian()
        {
            AmphibianList.Add(amphibian);
            AnimalAddNotify?.Invoke("Amphibian", amphibian);
            return $"Новое земноводное {amphibian.aSpecies} поселили в зоопарк.";
        }


    }
}
