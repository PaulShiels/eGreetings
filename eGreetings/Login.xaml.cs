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

namespace eGreetings
{
    public partial class Login : PhoneApplicationPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CreateAccount.xaml", UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserCredentials credentials = new UserCredentials(txtUsername.Text, txtPassword.Text);
            RunAsync(credentials);
            
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
                HttpResponseMessage response = await client.GetAsync("api/Values?username=" + credentials.Username + "&&password=" + credentials.Password);
                if (response.IsSuccessStatusCode)
                {
                    bool credentialsValid = await response.Content.ReadAsAsync<bool>();
                    MessageBox.Show(credentialsValid.ToString());
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
    }
}