using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the HttpClient
            httpClient = new HttpClient();

            // Load meals on startup
            LoadMeals();
        }

        private async Task LoadMeals()
        {
            // Make an HTTP GET request to the API endpoint for fetching meals
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5000/MealApi");

            if (response.IsSuccessStatusCode)
            {
                // Parse the response content to a list of meals
                List<MealDTO> meals = await response.Content.ReadAsAsync<List<MealDTO>>();

                // Set the ItemsSource of the mealItemsControl to the list of meals
                mealListBox.ItemsSource = meals;
            }
            else
            {
                // Handle the error case
                MessageBox.Show("Failed to load meals.");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (mealListBox.SelectedItem is MealDTO selectedMeal)
            {
                // Open the CreateMealWindow in update mode
                CreateMealWindow createMealWindow = new CreateMealWindow(selectedMeal);
                createMealWindow.ShowDialog();

                // Refresh the meals after the CreateMealWindow is closed
                LoadMeals();
            }
            else
            {
                // Open the CreateMealWindow in create mode
                CreateMealWindow createMealWindow = new CreateMealWindow();
                createMealWindow.ShowDialog();

                // Refresh the meals after the CreateMealWindow is closed
                LoadMeals();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (mealListBox.SelectedItem is MealDTO selectedMeal)
            {
                // Make an HTTP DELETE request to the API endpoint for deleting a meal
                HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:5000/MealApi/{selectedMeal.Id}");

                if (response.IsSuccessStatusCode)
                {
                    // Refresh the meals after successful deletion
                    LoadMeals();
                }
                else
                {
                    // Handle the error case
                    MessageBox.Show("Failed to delete the meal.");
                }
            }
            else
            {
                // Handle the case where no meal is selected
                MessageBox.Show("Please select a meal to delete.");
            }
        }
    }
}
