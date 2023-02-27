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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IEateView, IMenuView
    {
        /// <summary>
        /// содержит презентеры для всех частей модели
        /// </summary>
        SPMVP uPresenter;

        /// <summary>
        /// окно для пищевого склада
        /// </summary>
        FoodWindow foodWindow;
        /// <summary>
        /// окно для внесения данных о млекопитающем
        /// </summary>
        MammalWindow mammalWindow;
        BirdWindow birdWindow;
        AmphibianWindow amphibianWindow;

        /// <summary>
        /// управляется с помощью 
        /// uPresenter.menuPresenter
        /// uPresenter.eatePresenter
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            uPresenter = new SPMVP();
            uPresenter.menuPresenter.SetView(this);
            uPresenter.eatePresenter.SetView(this);

            AnimalListBox.ItemsSource = AnimalList.Animals;
            FoodListBox.ItemsSource = FoodList.foodList;

            AnimalListBox.SelectionChanged += (s, e) =>
            {
                if (AnimalListBox.SelectedItem != null)
                    SelectedAnimal.Text = (AnimalListBox.SelectedItem as IAnimal).Species;
            };
            FoodListBox.SelectionChanged += (s, e) =>
            {
                if (FoodListBox.SelectedItem != null)
                    SelectedFood.Text = (FoodListBox.SelectedItem as Food).foodName;
            };
            
            ResultButton.Click += (s,e) => uPresenter.eatePresenter.Result();
            ResultDeleteButton.Click += (s, e) => uPresenter.eatePresenter.DeleteFromZoo();

            SetZooMenuItemTest.Click += (s, e) => uPresenter.menuPresenter.DovnloadZooTest();
            SetZooMenuItemXML.Click += (s, e) => uPresenter.menuPresenter.DovnloadZooXML();
            SetZooMenuItemJSON.Click += (s, e) => uPresenter.menuPresenter.DovnloadZooJSON();

            SaveZooMenuItemXML.Click += (s, e) => uPresenter.menuPresenter.SaveZooXML();
            SaveZooMenuItemJSON.Click += (s, e) => uPresenter.menuPresenter.SaveZooJSON();
        }

        public void NewZooDownloaded() 
        {
            AnimalListBox.ItemsSource = AnimalList.Animals;
            FoodListBox.ItemsSource = FoodList.foodList;
        }

        public AnimalList AnimalList { get; set; }
        public FoodList FoodList { get; set; }


        public IAnimal animal { get => AnimalListBox.SelectedItem as IAnimal; }
        public Food food { get => FoodListBox.SelectedItem as Food; }
        public string Result { set => this.EateResultTextBlock.Text = value; }

        public string DeleteResult { set => this.DeleteResultTextBlock.Text = value; }

        public void AnimalListChanged() 
        {
            AnimalListBox.UnselectAll();
            AnimalListBox.Items.Refresh();
        }

        public void FoodChanged() 
        {
            FoodListBox.UnselectAll();
            FoodListBox.Items.Refresh();
        }
        private void FoodMenuItem_Click(object sender, RoutedEventArgs e)
        {
            foodWindow = new FoodWindow(uPresenter.foodPresenter);
            foodWindow.Show();
        }

        private void MammalMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mammalWindow = new MammalWindow(uPresenter.mammalPresenter);
            mammalWindow.Show();
        }

        private void BirdMenuItem_Click(object sender, RoutedEventArgs e)
        {
            birdWindow = new BirdWindow(uPresenter.birdPresenter);
            birdWindow.Show();
        }

        private void AmphibianMenuItem_Click(object sender, RoutedEventArgs e)
        {
            amphibianWindow = new AmphibianWindow(uPresenter.amphibianPresenter);
            amphibianWindow.Show();
        }
    }
}
