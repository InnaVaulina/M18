using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public interface IEateModel
    {
        AnimalList AnimalList { get; set; }
        FoodList FoodList { get; set; }

        event AnimalAddHandler AnimalAddNotify;
        event FoodChangedHandler FoodNotify;
        event AnimalListChangedHandler AnimalListChanged;
        string Result();
        string DeleteAnimal();

        void GetDate(IAnimal animal, Food food);

        void GetDateAboutZoo(ZooDimensions zoo);

    }

    public interface IEateView
    {
        
        AnimalList AnimalList { get; set; }
        FoodList FoodList { get; set; }

        void NewZooDownloaded();

        IAnimal animal { get; }
        Food food { get; }
        string Result { set; }
        string DeleteResult { set; }

        void AnimalListChanged();
        void FoodChanged();
    }


    public class EatePresenter
    {
        IEateModel model;
        IEateView view;

       
        public EatePresenter(IEateModel model)
        {
            this.view = null;
            this.model = model;
            this.model.AnimalAddNotify += (s,e) => view.AnimalListChanged();
            this.model.FoodNotify += () => view.FoodChanged();
            this.model.AnimalListChanged += () =>
            {
                view.AnimalList = model.AnimalList;
                view.FoodList = model.FoodList;
                view.NewZooDownloaded();
            };
        }

        public void SetView(IEateView view) 
        {
            this.view = view;
            view.AnimalList = model.AnimalList;
            view.FoodList = model.FoodList;
        }


        public void ZooDownloaded(ZooDimensions zoo)
        {
            view.AnimalList = model.AnimalList;
            view.FoodList = model.FoodList;
            view.NewZooDownloaded();
        }

        public void Result()
        {
            try
            {
                model.GetDate(view.animal, view.food);
                view.Result = model.Result();
            }
            catch (Exception ex) { view.Result = ex.Message; }

        }

        public void DeleteFromZoo() 
        {
            try
            {                
                view.DeleteResult = model.DeleteAnimal();
                view.AnimalListChanged();
            }
            catch (Exception ex) { view.DeleteResult = ex.Message; }
        }


    }
}
