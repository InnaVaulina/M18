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
    /// Логика взаимодействия для BirdWindow.xaml
    /// </summary>
    public partial class BirdWindow : Window, IBirdView

    {
        BirdPresenter birdPresenter;
        public BirdWindow(BirdPresenter bPresenter)
        {
            InitializeComponent();
            birdPresenter = bPresenter;
            birdPresenter.SetView(this);
            BirdListBox.ItemsSource = BirdList;

            AddNewBirdButton.Click += (s, e) =>
            {
                birdPresenter.AddNewMammalResult();
                BirdListBox.UnselectAll();
                BirdListBox.Items.Refresh();
            };
        }

        public List<BirdParametres> BirdList { get; set; }

        public string bSpecies { get => bSpeciesTextBox.Text; }
        public string bFood { get => bFoodTextBox.Text; }
        public string bLimitDayFood { get => bLimitDayFoodTextBox.Text; }
        public string airSpeed { get => airSpeedTextBox.Text; }

        public string BirdAddResult { set => BirdAddResultTextBox.Text = value; }
    }
}