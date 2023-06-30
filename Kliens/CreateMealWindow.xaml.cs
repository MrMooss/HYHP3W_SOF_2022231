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
using Microsoft.Win32;

namespace Kliens
{
    /// <summary>
    /// Interaction logic for CreateMealWindow.xaml
    /// </summary>
    public partial class CreateMealWindow : Window
    {
        public ViewMeal? selectedMeal { get; set; }

        private string selectedFilePath;

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
                pathToImage.Text = selectedMeal.ImageUrl;
            }
            this.DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            //selectedFilePath képet blob-ba
            MealDTO mealDTO = new MealDTO()
            {
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                ConsumptionDate = (DateTime)consumptionDatePicker.SelectedDate,
                MealType = (MealType)MealTypeComboBox.SelectedValue,
                ImageUrl = "", // blob url
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
            if (selectedMeal != null)
            {
                selectedMeal = null;
            }
            Close();
        }


        private void OnEntityCreated(MealDTO createdEntity)
        {
            EntityCreated?.Invoke(this, new EntityCreatedEventArgs(createdEntity));
        }


        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
                pathToImage.Text = selectedFilePath;
            }  
        }
    }
}
