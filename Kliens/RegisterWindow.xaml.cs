using Kliens.ViewModel;
using Common.BlobLogic;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Kliens
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        RegisterViewModel model = new RegisterViewModel();
        BlobLogic bl = new BlobLogic();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            LoginWindow windw = new LoginWindow();
            Close();
            windw.Show();
            
        }

        private async void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7289");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
            string imageurl = await bl.Upload(pathToImage.Text);
            model.Password = password.Password;
            model.UserEmail = email.Text;
            model.PhotoUrl = imageurl;
            model.UserName = email.Text;
            var response = await client.PutAsJsonAsync<RegisterViewModel>("auth", model);

            if (response.IsSuccessStatusCode)
            {
                var result = MessageBox.Show("Registration succesful", "Info", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                this.DialogResult = true;
            }
        }

        private void SelectImageClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.jpeg";
            if (ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                pathToImage.Text = filename;
            }
        }

        private void OnCloseEvent(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }
    }
}
