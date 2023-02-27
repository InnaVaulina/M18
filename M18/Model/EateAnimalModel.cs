using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// жизнь в зоопарке
    /// </summary>
    public class EateAnimalModel : IEateModel 
    {
        /// <summary>
        /// животные всех видов
        /// </summary>
        public AnimalList AnimalList { get; set; }

        /// <summary>
        /// пища всех видов
        /// </summary>
        public FoodList FoodList { get; set; }

        /// <summary>
        /// фабрика для поселения животного в зоопарк
        /// </summary>
        private AnimalFactory factory { get; set; }

        /// <summary>
        /// животное
        /// </summary>
        private IAnimal animal;

        /// <summary>
        /// пища
        /// </summary>
        private Food food;

        /// <summary>
        /// все данных о животных загружены заново
        /// сообщить в презентер
        /// </summary>
        public event AnimalListChangedHandler AnimalListChanged;

        /// <summary>
        /// добавлено одно животное
        /// сообщить в презентер
        /// </summary>
        public event AnimalAddHandler AnimalAddNotify;

        /// <summary>
        /// добавлена или удалена еда
        /// сообщить в презентер
        /// </summary>
        public event FoodChangedHandler FoodNotify;

        /// <summary>
        /// данные для кормления животного
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="food"></param>
        /// <exception cref="Exception"></exception>
        public void GetDate(IAnimal animal, Food food) 
        {
            if (animal == null) throw new Exception("Какое животное?");
            else this.animal = animal;
            if (food == null) throw new Exception("Какой едой?");
            else this.food = food;
        }

        /// <summary>
        /// результат кормления животного
        /// </summary>
        /// <returns></returns>
        public string Result() 
        {
            animal.Eat(food);
            switch (animal.LiveState) 
            {
                case "full": return $"{animal.Species} сыт";
                case "hungry": return $"{animal.Species} голоден";
                case "veryHungry": return $"{animal.Species} очень голоден";
                case "veryveryHungry": return $"{animal.Species} истощен";
                case "died": return $"{animal.Species} издох";
                default: return $"{animal.Species} в неопределенном состоянии"; ;
            }
        }

        public EateAnimalModel() 
        {
            AnimalList = new AnimalList();
            FoodList = new FoodList();
            factory = new AnimalFactory();
        }

        /// <summary>
        /// при загрузке данных о зоопарке
        /// поселение множества животных в зоопарк
        /// и заполнение пищевого склада
        /// </summary>
        /// <param name="zoo"></param>
        public void GetDateAboutZoo(ZooDimensions zoo)
        {
            AnimalList = new AnimalList();
            FoodList = new FoodList();
            

            foreach(var m in zoo.MammalParametres) 
                if(m.liveState != "died")
                    AnimalList.Add(factory.AFactory("Mammal", m));
            foreach(var b in zoo.BirdParametres)
                if (b.liveState != "died")
                    AnimalList.Add(factory.AFactory("Bird", b));
            foreach(var a in zoo.AmphibianParametres)
                if (a.liveState != "died")
                    AnimalList.Add(factory.AFactory("Amphibian", a));

            FoodList = zoo.FoodList;

            AnimalListChanged?.Invoke();

        }

        /// <summary>
        /// поселение животного в зоопарк
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="animalParametres"></param>
        public void AddAnimal(string animal, AnimalParametres animalParametres) 
        {
            AnimalList.Add(factory.AFactory(animal, animalParametres));
            AnimalAddNotify?.Invoke(animal, animalParametres);
        }

        /// <summary>
        /// изменение данных о пище на складе
        /// </summary>
        public void FoodChanged() 
        {
            FoodNotify?.Invoke();
        }

        /// <summary>
        /// удаление умерших животных
        /// </summary>
        /// <returns></returns>
        public string DeleteAnimal()
        {
            return AnimalList.Remove();
        }


    }
}
