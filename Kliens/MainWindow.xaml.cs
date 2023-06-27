using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
using Common.DTOs;
using Kliens.ViewModel;

namespace Kliens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient httpClient;
        public MealDTO SelectedMeal { get; set; }
        List<ViewMeal> viewMeals;

        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            LoadMeals();
        }

        private async Task LoadMeals()
        {
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5000/MealApi");

            if (response.IsSuccessStatusCode)
            {
                List<MealDTO> meals = await response.Content.ReadAsAsync<List<MealDTO>>();

                viewMeals = meals.Select(meal => new ViewMeal
                {
                    Id = meal.Id,
                    Name = meal.Name,
                    Description = meal.Description,
                    ImageUrl = meal.ImageUrl,
                    ConsumptionDate = meal.ConsumptionDate,
                    MealType = meal.MealType,
                    RecipeDescription = meal.Recipe.Description,
                    RecipeID = meal.Recipe.Id
                }).ToList();

                mealListBox.ItemsSource = viewMeals;
            }
            else
            {
                MessageBox.Show("Failed to load meals.");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (mealListBox.SelectedItem is ViewMeal selectedMeal)
            {
                CreateMealWindow createMealWindow = new CreateMealWindow(selectedMeal);
                createMealWindow.ShowDialog();
                LoadMeals();
            }
            else
            {
                CreateMealWindow createMealWindow = new CreateMealWindow();
                createMealWindow.ShowDialog();
                LoadMeals();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (mealListBox.SelectedItem is ViewMeal selectedMeal)
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:5000/MealApi/{selectedMeal.Id}");

                if (response.IsSuccessStatusCode)
                {
                    LoadMeals();
                }
                else
                {
                    MessageBox.Show("Failed to delete the meal.");
                }
            }
            else
            {
                MessageBox.Show("Please select a meal to delete.");
            }
        }
    }
}
