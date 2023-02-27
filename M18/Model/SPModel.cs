using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// связка всех объектов Model
    /// </summary>
    public class SPModel
    {
        ZooDimensions zoo;

        /// <summary>
        /// содержит все данные о зоопарке
        /// в случае обновления данных о зоопарке, все Model получают данные заново
        /// </summary>
        public ZooDimensions Zoo 
        { 
            get { return zoo; } 
            set 
            { 
                zoo = value;
                eateAnimal.GetDateAboutZoo(zoo);
                food.FoodList = zoo.FoodList;
                mammal.MammalList = zoo.MammalParametres;
                bird.BirdList = zoo.BirdParametres;
                amphibian.AmphibianList = zoo.AmphibianParametres;
            } 
        }

        public MenuModel menu;              // меню
        public EateAnimalModel eateAnimal;  // питание животных
        public FoodModel food;              // поставка пищи
        public MammalModel mammal;          // поселение млекопитающих в зоопарк
        public BirdModel bird;              // поселение птиц в зоопарк
        public AmphibianModel amphibian;    // поселение земноводных в зоопарк

        /// <summary>
        /// создание модели и связки между элементами
        /// </summary>
        public SPModel() 
        {
            zoo= new ZooDimensions();
            menu = new MenuModel(this);
            eateAnimal = new EateAnimalModel();
            food = new FoodModel(zoo.FoodList);
            food.FoodNotify += eateAnimal.FoodChanged;
            mammal = new MammalModel(zoo.MammalParametres);
            mammal.AnimalAddNotify += eateAnimal.AddAnimal;
            bird = new BirdModel(zoo.BirdParametres);
            bird.AnimalAddNotify += eateAnimal.AddAnimal;
            amphibian = new AmphibianModel(zoo.AmphibianParametres);
            amphibian.AnimalAddNotify += eateAnimal.AddAnimal;
        }

        
    }
}
