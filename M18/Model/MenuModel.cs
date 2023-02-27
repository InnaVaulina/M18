using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// сохранение / извлечение данных о зоопарке
    /// </summary>
    public class MenuModel: IMenuModel
    {
        SPModel main;
        public ZooDimensions Zoo { 
            get { return main.Zoo; } 
            set { main.Zoo = value; } }


        ZooSaver saver;
        ZooSaverTest saver0;
        ZooSaverXML saverXML;
        ZooSaverJSON saverJ;

        public MenuModel(SPModel main) 
        {
            this.main = main;
            this.saver0 = new ZooSaverTest("");
            this.saverXML = new ZooSaverXML("zoo.xml");
            this.saverJ = new ZooSaverJSON("zoo.json");
            this.saver = new ZooSaver(saver0);

        }

        /// <summary>
        /// выбор формата для сохранения/загрузки данных
        /// </summary>
        /// <param name="mode"></param>
        public void ChangeSaverMode(string mode) 
        {
            switch (mode) 
            {
                case "test": saver.Mode = saver0; break;
                case "XML": saver.Mode = saverXML;break;
                case "JSON": saver.Mode = saverJ;break;
                default: saver.Mode = saver0; break;
            }
            
        }

        /// <summary>
        /// сохранить зоопарк
        /// </summary>
        public void SaveZoo()
        {
            saver.Mode.Zoo = Zoo;
            saver.SaveZoo();          
        }

        /// <summary>
        /// загрузить зоопарк
        /// </summary>
        public void DovnloadZoo() 
        {
            saver.DovnloadZoo();
            Zoo = saver.Mode.Zoo;
        }
    }
}
