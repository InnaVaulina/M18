using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public interface IMammalModel
    {
        List<MammalParametres> MammalList { get; set; }
        event AnimalListChangedHandler AnimalListChanged;
        void GetDateToAddMammal(string name, string food, string fcount, string speed);

        string AddMammal();
    }

    public interface IMammalView
    {
        List<MammalParametres> MammalList { get; set; }
        string mSpecies { get; }         
        string mFood { get; }            
        string mLimitDayFood { get; } 
        string earthSpeed { get; }
        string MammalAddResult { set; }
        
    }


    public class MammalPresenter
    {
        IMammalModel model;
        IMammalView view;



        public MammalPresenter(IMammalModel model)
        {
            this.view = null;
            this.model = model;

        }

        public void SetView(IMammalView view)
        {
            this.view = view;
            this.view.MammalList = this.model.MammalList;
            this.model.AnimalListChanged += () => 
            { this.view.MammalList = this.model.MammalList; };

        }

        public void AddNewMammalResult()
        {
            try
            {
                model.GetDateToAddMammal(view.mSpecies, view.mFood, view.mLimitDayFood, view.earthSpeed);
                view.MammalAddResult = model.AddMammal();
            }
            catch (Exception ex) { view.MammalAddResult = ex.Message; }

        }


    }
}
