using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M18
{
    /// <summary>
    /// Логика взаимодействия для MammalWindow.xaml
    /// </summary>
    public partial class MammalWindow : Window, IMammalView
    {
        MammalPresenter mammalPresenter;
        public MammalWindow(MammalPresenter mPresenter)
        {
            InitializeComponent();
            mammalPresenter = mPresenter;
            mammalPresenter.SetView(this);
            MammalListBox.ItemsSource = MammalList;

            AddNewMammalButton.Click += (s, e) =>
            {
                mammalPresenter.AddNewMammalResult();
                MammalListBox.UnselectAll();
                MammalListBox.Items.Refresh();
            };
        }

        public List<MammalParametres> MammalList { get; set; }

        public string mSpecies { get => mSpeciesTextBox.Text; }
        public string mFood { get => mFoodTextBox.Text; }
        public string mLimitDayFood { get => mLimitDayFoodTextBox.Text; }
        public string earthSpeed { get => earthSpeedTextBox.Text; }

        public string MammalAddResult { set => MammalAddResultTextBox.Text = value; }

    }
}
