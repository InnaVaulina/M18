using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public interface IAmphibianModel
    {
        List<AmphibianParametres> AmphibianList { get; set; }
        event AnimalListChangedHandler AnimalListChanged;
        void GetDateToAddAmphibian(string name, string food, string fcount, string speed);

        string AddAmphibian();
    }

    public interface IAmphibianView
    {
        List<AmphibianParametres> AmphibianList { get; set; }
        string aSpecies { get; }
        string aFood { get; }
        string aLimitDayFood { get; }
        string waterSpeed { get; }
        string AmphibianAddResult { set; }

    }


    public class AmphibianPresenter
    {
        IAmphibianModel model;
        IAmphibianView view;



        public AmphibianPresenter(IAmphibianModel model)
        {
            this.view = null;
            this.model = model;
            
        }

        public void SetView(IAmphibianView view)
        {
            this.view = view;
            this.view.AmphibianList = this.model.AmphibianList;
            this.model.AnimalListChanged += () => 
            { this.view.AmphibianList = this.model.AmphibianList; };
        }

        public void AddNewMammalResult()
        {
            try
            {
                model.GetDateToAddAmphibian(view.aSpecies, view.aFood, view.aLimitDayFood, view.waterSpeed);
                view.AmphibianAddResult = model.AddAmphibian();
            }
            catch (Exception ex) { view.AmphibianAddResult = ex.Message; }

        }



    }
}
