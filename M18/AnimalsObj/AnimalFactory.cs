using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// создание объектов, реализующих поведение животных
    /// </summary>
    public class AnimalFactory
    {

        public IAnimal AFactory(string animal, AnimalParametres animalParametres) 
        {
            if (animalParametres != null)
            {
                switch (animal)
                {
                    case "Mammal":
                        return new Mammal(animalParametres as MammalParametres);
                    case "Bird":
                        return new Bird(animalParametres as BirdParametres);
                    case "Amphibian":
                        return new Amphibian(animalParametres as AmphibianParametres);
                    default:
                        return new UnknownAnimal(animalParametres as UnknownAnimalParametres);
                }
            }
            else return new UnknownAnimal();          
        }
    }
}
