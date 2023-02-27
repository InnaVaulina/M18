using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M18
{
    /// <summary>
    /// содержит все презентеры и Model
    /// </summary>
    public class SPMVP
    {
        SPModel model;

        public MenuPresenter menuPresenter { get; set; }
        public EatePresenter eatePresenter { get; set; }
        public FoodPresenter foodPresenter { get; set; }
        public MammalPresenter mammalPresenter { get; set; }
        public BirdPresenter birdPresenter { get; set; }
        public AmphibianPresenter amphibianPresenter { get; set; }

        public SPMVP()
        {
            this.model = new SPModel();
            this.menuPresenter = new MenuPresenter(model.menu);
            this.eatePresenter = new EatePresenter(model.eateAnimal);
            this.foodPresenter = new FoodPresenter(model.food);
            this.mammalPresenter = new MammalPresenter(model.mammal);
            this.birdPresenter = new BirdPresenter(model.bird);
            this.amphibianPresenter = new AmphibianPresenter(model.amphibian);

        }
    }
}
