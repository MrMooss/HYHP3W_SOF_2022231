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
using Common.DTOs;
using Kliens.ViewModel;

namespace Kliens
{
    /// <summary>
    /// Interaction logic for CreateMealWindow.xaml
    /// </summary>
    public partial class CreateMealWindow : Window
    {
        ViewMeal selectedMeal;

        public CreateMealWindow()
        {
            InitializeComponent();
        }

        public CreateMealWindow(ViewMeal selectedMeal)
        {
            InitializeComponent();
            this.selectedMeal = selectedMeal;

            if (this.selectedMeal != null)
            {
                nameTextBox.Text = selectedMeal.Name;
                descriptionTextBox.Text = selectedMeal.Description;
                mealTypeComboBox.SelectedItem = selectedMeal.MealType;
                consumptionDatePicker.SelectedDate = selectedMeal.ConsumptionDate;
                recipeTextBox.Text = selectedMeal.RecipeDescription;
            }
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
