using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// реализует поведение животного
    /// </summary>
    public interface IAnimal
    {
        /// <summary>
        /// вид животного
        /// </summary>
        string Species { get; }

        /// <summary>
        /// состояние после кормления
        /// </summary>
        string LiveState { get; set; }

        /// <summary>
        /// кормление
        /// </summary>
        /// <param name="food"></param>
        void Eat(Food food);

    }
  
}
