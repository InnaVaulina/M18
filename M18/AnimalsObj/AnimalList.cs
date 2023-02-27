using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// животные
    /// </summary>
    public class AnimalList
    {
        public List<IAnimal> Animals { get; }

        public AnimalList() 
        {
            Animals = new List<IAnimal>();

        }

        public void Add(IAnimal animal) 
        {
            Animals.Add(animal);           
        }

        public string Remove() 
        {          
            string result = "все животные живы";
            int c = 0;
            
            for(int i=0; i<Animals.Count; i++) 
            {
                if (Animals[i].LiveState == "died")
                {
                    Animals.Remove(Animals[i]);
                    c++;
                }
            }
            if (c == 0) return result;
            else return $"{c} животных погибло";
        }

        public IAnimal this[string animal] 
        {
            get 
            {
                foreach (var an in Animals) 
                { if (an.Species == animal) return an; }
                return null;
            }
        }
    }
}
