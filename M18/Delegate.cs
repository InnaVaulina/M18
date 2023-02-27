using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public delegate void AnimalAddHandler(string animal, AnimalParametres animalParametres);
    
    public delegate void FoodChangedHandler();
    public delegate void AnimalListChangedHandler();
}
