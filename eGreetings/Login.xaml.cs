using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO.IsolatedStorage;
using System.IO;

namespace eGreetings
{
    public partial class Login : PhoneApplicationPage
    {
        private static bool loginSuccess;
        private  UserCredentials credentials;

        public Login()
        {
            InitializeComponent();
            LayoutRoot.Background = App.Current.appBackgroundImage;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            txtLogin.FontFamily = fontFamily;
            lblUsername.FontFamily = fontFamily;
            lblPassword.FontFamily = fontFamily;
            btnLogin.FontFamily = fontFamily;
            txtError.FontFamily = fontFamily;
            btnSignUp.FontFamily = fontFamily;
            txtLoggingIn.Visibility = Visibility.Collapsed;
            txtLoggingIn.FontFamily = fontFamily;
            txtError.FontFamily = fontFamily;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CreateAccount.xaml", UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            txtLoggingIn.Visibility = Visibility.Visible;
            txtError.Visibility = Visibility.Collapsed;
            
            credentials = new UserCredentials(txtUsername.Text, txtPassword.Text);
            saveAccountIsolatedStorage(credentials);
            await RunAsync(credentials);

            if (loginSuccess)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                txtLoggingIn.Visibility = Visibility.Collapsed;
                txtError.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtLoggingIn.Visibility = Visibility.Collapsed;
                txtError.Visibility = Visibility.Visible;
            }
            //string uri = "http://egreetings.me/api/Values?" + credentials;  //username=" + txtUsername.Text + "&&password=" + txtPassword.Text;
            //WebClient client = new WebClient();
            //client.Headers["Accept"] = "application/json";
            //client.DownloadStringAsync(new Uri(uri));
            //client.DownloadStringCompleted += (s1, e1) =>
            //{
            //    var data = JsonConvert.DeserializeObject<bool>(e1.Result.ToString());
            //    MessageBox.Show(data.ToString());
            //};            
        }

        static async Task RunAsync( UserCredentials credentials)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://egreetings.me/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/Values?username=" + credentials.Username + "&&password=" + credentials.Password + "&&i=1");
                if (response.IsSuccessStatusCode)
                {
                    bool credentialsValid = await response.Content.ReadAsAsync<bool>();
                    loginSuccess = credentialsValid;
                    
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }

                

                // HTTP POST
                //var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                //response = await client.PostAsJsonAsync("api/products", gizmo);
                //if (response.IsSuccessStatusCode)
                //{
                //    Uri gizmoUrl = response.Headers.Location;

                //    // HTTP PUT
                //    gizmo.Price = 80;   // Update price
                //    response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

                //    // HTTP DELETE
                //    response = await client.DeleteAsync(gizmoUrl);
                //}
            }
        }

        public void saveAccountIsolatedStorage(UserCredentials user)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists("Login.store"))
                {
                    using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("Login.store", FileMode.Append, FileAccess.Write, isf)))
                    {
                        writeFile.WriteLine(user);
                        writeFile.Close();
                    }
                }
                else
                {
                    using (IsolatedStorageFileStream rawStream = isf.CreateFile("Login.store"))
                    {
                        StreamWriter writer = new StreamWriter(rawStream);
                        writer.WriteLine(user); // save the message
                        writer.Close();
                    }
                }
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnBackKeyPress(e);
        }
    }
}