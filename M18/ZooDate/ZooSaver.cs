using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace M18
{

    public class ZooSaver 
    {
        public IZooSave Mode { get; set; }

        public ZooSaver(IZooSave mode)
        {
            Mode = mode;
        }   

        public void SaveZoo() 
        {
            Mode.SaveZoo();
        }

        public void DovnloadZoo() 
        {
            Mode.DovnloadZoo();
        }

    }

    public interface IZooSave
    {

        ZooDimensions Zoo { get; set; }
        void SaveZoo();

        void DovnloadZoo();
    }

    


    public class ZooSaverXML: IZooSave 
    {
        private string fileName;
        public ZooDimensions Zoo { get; set; }

        public ZooSaverXML(string fileName)
        {
            this.fileName = fileName;
        }


        public void SaveZoo() 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ZooDimensions));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fStream, Zoo);
            fStream.Close();
        }

        public void DovnloadZoo() 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ZooDimensions));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            Zoo = xmlSerializer.Deserialize(fStream) as ZooDimensions;
            fStream.Close();
        }
    }

    public class ZooSaverJSON : IZooSave
    {
        private string fileName;
        public ZooDimensions Zoo { get; set; }

        public ZooSaverJSON(string fileName)
        {
            this.fileName = fileName;
        }

        public void SaveZoo()
        {

            string zooJson = JsonSerializer.Serialize(Zoo, typeof(ZooDimensions));
            StreamWriter file = File.CreateText(fileName);
            file.WriteLine(zooJson);
            file.Close();

        }

        public void DovnloadZoo()
        {
            if (File.Exists(fileName))
            {
                string data = File.ReadAllText(fileName);
                Zoo = JsonSerializer.Deserialize<ZooDimensions>(data);
            }
        }
    }

    public class ZooSaverTest : IZooSave
    {
        private string fileName;
        public ZooDimensions Zoo { get; set; }

        public ZooSaverTest(string fileName)
        {
            this.fileName = fileName;
        }

        public void SaveZoo()
        {

        }

        public void DovnloadZoo()
        {
            Zoo = StartZooParameters();
        }

        private ZooDimensions StartZooParameters()
        {
            ZooDimensions zoo = new ZooDimensions();
            zoo.MammalParametres.Add(new MammalParametres("крот", "черви", 1, 1));
            zoo.MammalParametres.Add(new MammalParametres("кролик", "травы", 1, 1));
            zoo.MammalParametres.Add(new MammalParametres("кот", "вискас", 1, 1));

            zoo.BirdParametres.Add(new BirdParametres("попугай", "пшено", 1, 1));
            zoo.BirdParametres.Add(new BirdParametres("перепел", "жуки", 1, 1));
            zoo.BirdParametres.Add(new BirdParametres("воробей", "овес", 1, 1));

            zoo.AmphibianParametres.Add(new AmphibianParametres("лягушка", "комары", 1, 1));
            zoo.AmphibianParametres.Add(new AmphibianParametres("саламандра", "жуки", 1, 1));

            zoo.FoodList.AddFood("пшено", 20);
            zoo.FoodList.AddFood("жуки", 20);
            zoo.FoodList.AddFood("овес", 20);
            zoo.FoodList.AddFood("черви", 20);
            zoo.FoodList.AddFood("травы", 20);
            zoo.FoodList.AddFood("вискас", 20);
            zoo.FoodList.AddFood("комары", 20);
            return zoo;
        }

    }
}
