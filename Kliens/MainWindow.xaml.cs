using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
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
using Common;
using Common.DTOs;
using Kliens.ViewModel;
using static Kliens.LoginWindow;

namespace Kliens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private HttpClient client;
        public ViewMeal SelectedMeal { get; set; }
        public ObservableCollection<ViewMeal> ViewMeals { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        TokenModel token;
        UserInfo userinfo;

        public MainWindow(TokenModel tokenModel)
        {
            InitializeComponent();
            DataContext = this;

            token = tokenModel;

            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7289");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
              new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);

            ViewMeals = new ObservableCollection<ViewMeal>()
            {
                new ViewMeal() { Name="Welcome", ImageUrl="https://upload.wikimedia.org/wikipedia/commons/b/b1/Loading_icon.gif", Description="Database loading, please wait"}
            };    

            Task.Run(async () =>
            {
                LoadMeals();
                userinfo = await GetUserInfo();
            }).Wait();

            usernamebox.Text = userinfo.UserName;
            profpics.Source = GetImage(userinfo.PhotoUrl);
            
        }

        public ImageSource GetImage(string url)
        {
            BitmapImage image = new BitmapImage();

            image.BeginInit();
            image.UriSource = new Uri(url);
            image.EndInit();

            return image;
        }

        private async Task LoadMeals()
        {
            HttpResponseMessage response = await client.GetAsync("/MealApi");

            if (response.IsSuccessStatusCode)
            {
                ObservableCollection<MealDTO> meals = await response.Content.ReadAsAsync<ObservableCollection<MealDTO>>();

                if (meals.Count > 0)
                {
                    var viewMealsList = meals.Select(meal => ViewMealFromDTO(meal));

                    ViewMeals = new ObservableCollection<ViewMeal>(viewMealsList);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ViewMeals"));
                }
            }
            else
            {
                MessageBox.Show("Failed to load meals.");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            CreateMealWindow createMealWindow = new CreateMealWindow();
            createMealWindow.EntityCreated += CreateWindow_EntityCreated;
            createMealWindow.ShowDialog();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (mealListBox.SelectedItem is ViewMeal selectedMeal)
            {
                CreateMealWindow createMealWindow = new CreateMealWindow(selectedMeal);
                createMealWindow.EntityCreated += CreateWindow_UpdateEntity;
                createMealWindow.ShowDialog();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (mealListBox.SelectedItem is ViewMeal selectedMeal)
            {
                HttpResponseMessage response = await client.DeleteAsync($"/MealApi/{selectedMeal.Id}");

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

        async Task<UserInfo> GetUserInfo()
        {
            var response = await client.GetAsync("auth");
            Debug.Write(response);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<UserInfo>();
            }
            throw new Exception("something wrong...");
        }

        private async void CreateWindow_EntityCreated(object sender, EntityCreatedEventArgs e)
        {
            e.CreatedEntity.Id = "";
            var response = await client.PostAsJsonAsync("/MealApi", e.CreatedEntity);
            if (response.IsSuccessStatusCode) 
            {
                LoadMeals();
            }
        }

        private async void CreateWindow_UpdateEntity(object sender, EntityCreatedEventArgs e)
        {
            var response = await client.PutAsJsonAsync("/MealApi", e.CreatedEntity);
            response.EnsureSuccessStatusCode();
            LoadMeals();
        }

        private ViewMeal ViewMealFromDTO(MealDTO meal)
        {
            ViewMeal vm = new ViewMeal()
            {
                Id = meal.Id,
                Name = meal.Name,
                Description = meal.Description,
                ImageUrl = meal.ImageUrl,
                ConsumptionDate = meal.ConsumptionDate,
                MealType = meal.MealType,
                RecipeDescription = meal.Recipe.Description,
                RecipeID = meal.Recipe.Id
            };
            
            return vm;
        }
    }
}
