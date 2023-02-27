using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    public abstract class AnimalParametres
    {

    }

    /// <summary>
    /// данные о земноводном
    /// </summary>
    public class AmphibianParametres : AnimalParametres
    {
        public string aSpecies { get; set; }         // вид
        public string liveState { get; set; }        // состояние здоровья
        public string aFood { get; set; }            // еда
        public double aLimitDayFood { get; set; }    // количество еды в день
        public double waterSpeed { get; set; }       // скорость движения в воде

        public AmphibianParametres() 
        {
            this.aSpecies = "";
            this.aFood = "";
            this.aLimitDayFood = 0;
            this.waterSpeed = 0;
            this.liveState = "";
        }
        public AmphibianParametres(string aSpieces, string aFood, double aLimitDayFood, double waterSpeed)
        {
            this.aSpecies = aSpieces;
            this.aFood = aFood;
            this.aLimitDayFood = aLimitDayFood;
            this.waterSpeed = waterSpeed;
            this.liveState = "full";
        }
    }


    /// <summary>
    /// данные о птице
    /// </summary>
    public class BirdParametres : AnimalParametres
    {
        public string bSpecies { get; set; }         // вид
        public string liveState { get; set; }
        public string bFood { get; set; }            // еда
        public double bLimitDayFood { get; set; }    // количество еды в день
        public double airSpeed { get; set; }         // скорость движения в воздухе

        public BirdParametres() 
        {
            this.bSpecies = "";
            this.bFood = "";
            this.bLimitDayFood = 0;
            this.airSpeed = 0;
            this.liveState = "";
        }
        public BirdParametres(string aSpieces, string aFood, double bLimitDayFood, double airSpeed)
        {
            this.bSpecies = aSpieces;
            this.bFood = aFood;
            this.bLimitDayFood = bLimitDayFood;
            this.airSpeed = airSpeed;
            this.liveState = "full";
        }
    }



    /// <summary>
    /// данные о млекопитающем
    /// </summary>
    public class MammalParametres : AnimalParametres
    {
        public string mSpecies { get; set; }         // вид
        public string liveState { get; set; }
        public string mFood { get; set; }            // еда
        public double mLimitDayFood { get; set; }    // количество еды в день
        public double earthSpeed { get; set; }       // скорость движения по земле

        public MammalParametres() 
        {
            this.mSpecies = "";
            this.mFood = "";
            this.mLimitDayFood = 0;
            this.earthSpeed = 0;
            this.liveState = "";
        }
        public MammalParametres(string aSpieces, string aFood, double mLimitDayFood, double earthSpeed)
        {
            this.mSpecies = aSpieces;
            this.mFood = aFood;
            this.mLimitDayFood = mLimitDayFood;
            this.earthSpeed = earthSpeed;
            this.liveState = "full";
        }
    }


    public class UnknownAnimalParametres : AnimalParametres
    {
        public string uaSpecies { get; set; }
        public string liveState { get; set; }
        public string uaFood { get; set; }
        public double uaLimitDayFood { get; set; }

        public UnknownAnimalParametres() 
        {
            this.uaSpecies = "";
            this.uaFood = "";
            this.uaLimitDayFood = 0;
            this.liveState = "";
        }
        public UnknownAnimalParametres(string aSpieces, string aFood, double aLimitDayFood)
        {
            this.uaSpecies = aSpieces;
            this.uaFood = aFood;
            this.uaLimitDayFood = aLimitDayFood;
            this.liveState = "full";
        }
    }
}
