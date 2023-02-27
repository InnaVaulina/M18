using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public interface IFoodModel
    {
        FoodList FoodList { get; set; }
        void GetDateToRemove(string f, string fc);
        string RemoveFood();

        void GetDateToAdd(string f, string fc);
        string AddFood();

    }

    public interface IFoodView
    {
        FoodList FoodList { get; set; }
        string RemoveFood { get; }
        string RemoveFoodCount { get; }
        string RemoveResult { set; }

        string NewFood { get; }
        string NewFoodCount { get; }
        string NewFoodAddResult { set; }

    }


    public class FoodPresenter
    {
        IFoodModel model;
        IFoodView view;

       

        public FoodPresenter(IFoodModel model)
        {
            this.view = null;
            this.model = model;
            
        }

        public void SetView(IFoodView view)
        {
            this.view = view;
            view.FoodList = model.FoodList;
        }

        public void RemoveFoodResult()
        {
            try
            {
                model.GetDateToRemove(view.RemoveFood, view.RemoveFoodCount);
                view.RemoveResult = model.RemoveFood();
            }
            catch (Exception ex) { view.RemoveResult = ex.Message; }

        }

        public void AddNewFoodResult()
        {
            try
            {
                model.GetDateToAdd(view.NewFood, view.NewFoodCount);
                view.NewFoodAddResult = model.AddFood();
            }
            catch (Exception ex) { view.NewFoodAddResult = ex.Message; }

        }


    }
}
