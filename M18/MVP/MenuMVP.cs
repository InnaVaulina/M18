using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public interface IMenuModel
    {
        ZooDimensions Zoo { get; }

        void ChangeSaverMode(string mode);
        void SaveZoo();
        void DovnloadZoo();

    }

    public interface IMenuView
    {
        

    }


    public class MenuPresenter
    {
        IMenuModel model;
        IMenuView view;


        public MenuPresenter(IMenuModel model)
        {

            this.view = null;
            this.model = model;
            
        }

        public void SetView(IMenuView view) 
        {
            this.view = view;
        }


        public void SaveZooTest() 
        {
            model.ChangeSaverMode("test");
            model.SaveZoo();
        }
        public void DovnloadZooTest() 
        {
            model.ChangeSaverMode("test");
            model.DovnloadZoo();
        }
        public void SaveZooXML() 
        {
            model.ChangeSaverMode("XML");
            model.SaveZoo();
        }
        public void DovnloadZooXML() 
        {
            model.ChangeSaverMode("XML");
            model.DovnloadZoo();
        }
        public void SaveZooJSON() 
        {
            model.ChangeSaverMode("JSON");
            model.SaveZoo();
        }
        public void DovnloadZooJSON() 
        {
            model.ChangeSaverMode("JSON");
            model.DovnloadZoo();
        }

    }
}
