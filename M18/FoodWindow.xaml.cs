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
    /// Логика взаимодействия для FoodWindow.xaml
    /// </summary>
    public partial class FoodWindow : Window, IFoodView
    {
        FoodPresenter foodPresenter;
        public FoodWindow(FoodPresenter foodPresenter)
        {
            InitializeComponent();
            this.foodPresenter = foodPresenter;
            foodPresenter.SetView(this);
            FoodListBox.ItemsSource = FoodList.foodList;

            FoodListBox.SelectionChanged += (s, e) =>
            {
                if (FoodListBox.SelectedItem != null) 
                {
                    Food f = FoodListBox.SelectedItem as Food;
                    SelectedFood.Text = f.foodName;
                    SelectedFoodCount.Text = f.foodCount.ToString();
                }       
            };

            DeleteFoodButton.Click += (s, e) =>
            {
                
                foodPresenter.RemoveFoodResult();
                FoodListBox.UnselectAll();
                FoodListBox.Items.Refresh();
            };

            AddNewFoodButton.Click += (s, e) =>
            {
                foodPresenter.AddNewFoodResult();
                FoodListBox.UnselectAll();
                FoodListBox.Items.Refresh();
            };

        }

        public FoodList FoodList { get; set; }

        public string RemoveFood { get => SelectedFood.Text; }
        public string RemoveFoodCount { get => SelectedFoodCount.Text; }

        public string RemoveResult { set => RemoveResultTextBox.Text = value; }

        public string NewFood { get => NewFoodTextBox.Text; }
        public string NewFoodCount { get => NewFoodCountTextBox.Text; }
        public string NewFoodAddResult { set => NewFoodAddResultTextBox.Text = value; }

    }
}
