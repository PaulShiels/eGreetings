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
using System.Collections.Specialized;
using System.Windows.Media;
using System.IO.IsolatedStorage;
using System.IO;

namespace eGreetings
{
    public partial class CreateAccount : PhoneApplicationPage
    {
        private static bool userAlreadyExists;
        private UserCredentials user;

        public CreateAccount()
        {
            InitializeComponent();
            LayoutRoot.Background = App.Current.appBackgroundImage;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            lblUsername.FontFamily = fontFamily;
            lblPassword.FontFamily = fontFamily;
            lblConforkmPassword.FontFamily = fontFamily;
            txtPasswordError.FontFamily = fontFamily;
            txtUserExistsError.FontFamily = fontFamily;
            btnLogin.FontFamily = fontFamily;            
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                txtPasswordError.Visibility = Visibility.Collapsed;
                UserCredentials credentials = new UserCredentials(txtUsername.Text, DateTime.Now.Date, txtPassword.Text);
                saveAccountIsolatedStorage(user);
                await CheckIfUserExists(credentials);
                if (!userAlreadyExists)
                {
                    user = new UserCredentials(txtUsername.Text, txtPassword.Text);
                    await SubmitNewUser(credentials);
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
                else
                {
                    txtUserExistsError.Visibility = Visibility.Visible;
                }
            }
            else
            {
                txtPasswordError.Visibility = Visibility.Visible;
            }

            ////Found this code at http://www.asp.net/web-api/overview/mobile-clients/calling-web-api-from-a-windows-phone-8-application
            
            ////Submit new account to the database
            ////http://egreetings.me/api/Values?username=Johnny&&dob=1982-03-04&&password=john

            //Uri address = new Uri("http://www.egreetings.me/api/Values", UriKind.Absolute);
            //string data = "/api/Values?"+credentials;
            //WebClient client = new WebClient();
            //try
            //{
            //    //client.BaseAddress = "http://www.egreetings.me";
            //    client.UploadStringAsync(address, "POST", data);
            //    client.UploadStringCompleted += client_UploadStringCompleted;
                
            //}
            //catch (Exception ex)
            //{

            //}
             
        }

        //void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        //{
        //    Dispatcher.BeginInvoke(() =>
        //    {
        //        if (e.Error == null)
        //            MessageBox.Show("WebClient: " + e.Result);
        //        else
        //            MessageBox.Show("WebClient: " + e.Error.Message);
        //    });
        //}


        static async Task CheckIfUserExists(UserCredentials credentials)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://egreetings.me/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/Values?username=" + credentials.Username + "&&password=" + credentials.Password + "&&i=9");
                if (response.IsSuccessStatusCode)
                {
                    bool credentialsValid = await response.Content.ReadAsAsync<bool>();
                    userAlreadyExists = credentialsValid;

                }
            }
        }

        static async Task SubmitNewUser(UserCredentials credentials)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://egreetings.me/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/Values?username=" + credentials.Username + "&&password=" + credentials.Password + "&&i=5");
                if (response.IsSuccessStatusCode)
                {
                    bool credentialsValid = await response.Content.ReadAsAsync<bool>();
                    //MessageBox.Show(credentialsValid.ToString());
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
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

//        static async Task RunAsync(UserCredentials credentials)
//        {
//            //var client = new HttpClient();
//            //client.BaseAddress = new Uri("http://egreetings.me/");
//            //client.DefaultRequestHeaders.Accept.Clear();
//            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//            //var content = JsonConvert.SerializeObject(credentials,Formatting.None);
//            //var stringContent = new StringContent(content.ToString());
//            //var response = await client.PostAsync("api/Values", stringContent);

//            //if (response.IsSuccessStatusCode)
//            //    {
//            //        //Uri gizmoUrl = response.Headers.Location;

//            //        // HTTP PUT
//            //        //gizmo.Price = 80;   // Update price
//            //        //response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

//            //        //// HTTP DELETE
//            //        //response = await client.DeleteAsync(gizmoUrl);
//            //    }

////client.PostAsync("http://localhost:44268/api/test", credentials).ContinueWith(
////    (postTask) =>
////    {
////        postTask.Result.EnsureSuccessStatusCode();
////    });

//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://egreetings.me/");
//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                // HTTP GET
//                //HttpResponseMessage response = await client.GetAsync("api/Values?username=" + credentials.Username + "&&password=" + credentials.Password);
//                //if (response.IsSuccessStatusCode)
//                //{
//                //    bool credentialsValid = await response.Content.ReadAsAsync<bool>();
//                //    MessageBox.Show(credentialsValid.ToString());
//                //    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
//                //}

//                // HTTP POST
//                //var gizmo = new User() { Name = "Gizmo", Price = 100, Category = "Widget" };
//                HttpResponseMessage response = await client.PostAsJsonAsync("api/Values", credentials);
//                if (response.IsSuccessStatusCode)
//                {
//                    //Uri gizmoUrl = response.Headers.Location;

//                    // HTTP PUT
//                    //gizmo.Price = 80;   // Update price
//                    //response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

//                    //// HTTP DELETE
//                    //response = await client.DeleteAsync(gizmoUrl);
//                }
//            }
//        }

    }
}