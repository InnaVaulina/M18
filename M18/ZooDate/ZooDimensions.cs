using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.NetworkInformation;

namespace M18
{
    /// <summary>
    /// зоопарк
    /// </summary>
    public class ZooDimensions
    {
        public List<MammalParametres> MammalParametres { get; set; }
        public List<BirdParametres> BirdParametres { get; set; }
        public List<AmphibianParametres> AmphibianParametres { get; set; }
        public FoodList FoodList { get; set; }

        public ZooDimensions() 
        {
            MammalParametres = new List<MammalParametres>();
            BirdParametres = new List<BirdParametres>();
            AmphibianParametres = new List<AmphibianParametres>();
            FoodList = new FoodList();
        }

        public void Remove() 
        {
            for (int i = 0; i < MammalParametres.Count; i++)
                if (MammalParametres[i].liveState == "died")
                    MammalParametres.Remove(MammalParametres[i]);
            for (int i = 0; i < BirdParametres.Count; i++)
                if (BirdParametres[i].liveState == "died")
                    BirdParametres.Remove(BirdParametres[i]);
            for (int i = 0; i < AmphibianParametres.Count; i++)
                if (AmphibianParametres[i].liveState == "died")
                    AmphibianParametres.Remove(AmphibianParametres[i]);
        }




    }
}
