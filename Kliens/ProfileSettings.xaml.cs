using Common.BlobLogic;
using Kliens.ViewModel;
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
using static Kliens.LoginWindow;

namespace Kliens
{
    /// <summary>
    /// Interaction logic for ProfileSettings.xaml
    /// </summary>
    public partial class ProfileSettings : Window
    {
        public RegisterViewModel ui { get; set; }
        TokenModel token;
        BlobLogic bl = new BlobLogic();

        Window main;

        public ProfileSettings(RegisterViewModel ui, TokenModel token, Window w)
        {
            InitializeComponent();

            this.main = w;
            this.ui = ui;
            this.token = token;
            DataContext = ui;


        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.jpeg";
            if (ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                txtPhotoUrl.Text = filename;
            }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://mealcalendar.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Add(
              new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);

            if (!Uri.IsWellFormedUriString(txtPhotoUrl.Text, UriKind.Absolute))
            {
                ui.PhotoUrl = await bl.Upload(txtPhotoUrl.Text);
            }
            else
                ui.PhotoUrl = txtPhotoUrl.Text;
            if (txtPassword.Password == string.Empty)
            {
                ui.Password = "";
            }
            else
            {
                ui.Password = txtPassword.Password;
            }
            var response = await client.PostAsJsonAsync<RegisterViewModel>("auth/update", ui);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Successful update, please relogin");
                LoginWindow login = new LoginWindow();
                main.Close();
                this.Close();
                login.Show();

            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete your account? This cannot be reversed.", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://mealcalendar.azurewebsites.net");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);

                if (!Uri.IsWellFormedUriString(txtPhotoUrl.Text, UriKind.Absolute))
                {
                    MessageBox.Show("Wrong image URL");
                    return;
                }

                await bl.Delete(txtPhotoUrl.Text);

                var res = await client.DeleteAsync("auth");
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Successful delete");
                    LoginWindow login = new LoginWindow();
                    main.Close();
                    this.Close();
                    login.Show();

                }
            }
        }
    }
}
