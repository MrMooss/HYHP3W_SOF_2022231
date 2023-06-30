using Kliens.ViewModel;
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

namespace Kliens
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7289");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

            var response = await client.PostAsJsonAsync<LoginViewModel>("auth", new LoginViewModel()
            {
                UserEmail = emailTextBox.Text,
                Password = passwordBox.Password
            });

            var token = await response.Content.ReadAsAsync<TokenModel>();
            token.Expiration = token.Expiration.ToLocalTime();

            MainWindow mw = new MainWindow(token);
            mw.ShowDialog();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            Close();
            rw.ShowDialog();
        }

        internal class SocialToken
        {
            public string Token { get; set; }
        }
    }
}
