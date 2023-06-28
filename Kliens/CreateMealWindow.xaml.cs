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
using Common;
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

        public event EventHandler<EntityCreatedEventArgs> EntityCreated;
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
                MealTypeComboBox.SelectedItem = selectedMeal.MealType;
                consumptionDatePicker.SelectedDate = selectedMeal.ConsumptionDate;
                recipeTextBox.Text = selectedMeal.RecipeDescription;
            }
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MealDTO mealDTO = new MealDTO()
            {
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                ConsumptionDate = (DateTime)consumptionDatePicker.SelectedDate,
                MealType = (MealType)MealTypeComboBox.SelectedValue,
                ImageUrl = "", //Upload image and return url
                Recipe = new RecipeDTO()
                {
                    Description = recipeTextBox.Text,
                    Name = nameTextBox.Text
                }
            };

            OnEntityCreated(mealDTO);
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void OnEntityCreated(MealDTO createdEntity)
        {
            EntityCreated?.Invoke(this, new EntityCreatedEventArgs(createdEntity));
        }
    }
}
