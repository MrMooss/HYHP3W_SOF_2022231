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

namespace Kliens
{
    /// <summary>
    /// Interaction logic for CreateMealWindow.xaml
    /// </summary>
    public partial class CreateMealWindow : Window
    {
        public CreateMealWindow()
        {
            InitializeComponent();
        }

        public CreateMealWindow(MealDTO selectedMeal)
        {
            InitializeComponent();
            // Use the selectedMeal parameter to populate the window fields or perform any other necessary logic
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
