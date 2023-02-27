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
    /// Логика взаимодействия для AmphibianWindow.xaml
    /// </summary>
    public partial class AmphibianWindow : Window, IAmphibianView

    {
        AmphibianPresenter amphibianPresenter;
        public AmphibianWindow(AmphibianPresenter aPresenter)
        {
            InitializeComponent();
            amphibianPresenter = aPresenter;
            amphibianPresenter.SetView(this);
            AmphibianListBox.ItemsSource = AmphibianList;

            AddNewAmphibianButton.Click += (s, e) =>
            {
                amphibianPresenter.AddNewMammalResult();
                AmphibianListBox.UnselectAll();
                AmphibianListBox.Items.Refresh();
            };
        }

        public List<AmphibianParametres> AmphibianList { get; set; }

        public string aSpecies { get => aSpeciesTextBox.Text; }
        public string aFood { get => aFoodTextBox.Text; }
        public string aLimitDayFood { get => aLimitDayFoodTextBox.Text; }
        public string waterSpeed { get => waterSpeedTextBox.Text; }

        public string AmphibianAddResult { set => AmphibianAddResultTextBox.Text = value; }
    }
}
