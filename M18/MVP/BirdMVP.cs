using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public interface IBirdModel
    {
        List<BirdParametres> BirdList { get; set; }
        event AnimalListChangedHandler AnimalListChanged;
        void GetDateToAddBird(string name, string food, string fcount, string speed);

        string AddBird();
    }

    public interface IBirdView
    {
        List<BirdParametres> BirdList { get; set; }
        string bSpecies { get; }
        string bFood { get; }
        string bLimitDayFood { get; }
        string airSpeed { get; }
        string BirdAddResult { set; }

    }


    public class BirdPresenter
    {
        IBirdModel model;
        IBirdView view;



        public BirdPresenter(IBirdModel model)
        {
            this.view = null;
            this.model = model;
            
        }

        public void SetView(IBirdView view)
        {
            this.view = view;
            this.view.BirdList = this.model.BirdList;
            this.model.AnimalListChanged += () => 
            { this.view.BirdList = this.model.BirdList; };
        }

        public void AddNewMammalResult()
        {
            try
            {
                model.GetDateToAddBird(view.bSpecies, view.bFood, view.bLimitDayFood, view.airSpeed);
                view.BirdAddResult = model.AddBird();
            }
            catch (Exception ex) { view.BirdAddResult = ex.Message; }

        }

       


    }
}
