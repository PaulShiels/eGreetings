using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using eGreetings.Resources;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Windows.Media;

namespace eGreetings
{
    public partial class MainPage : PhoneApplicationPage
    {
        private static List<string> templateImagesStrings = new List<string>();
        private static List<string> objectImageStrings = new List<string>();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            App.Current.selectedImage = new Image() { Source = new BitmapImage(new Uri("http://ww1.prweb.com/prfiles/2014/04/10/11752526/gI_134971_best-image-web-hosting.png", UriKind.Absolute)) };
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {            
            ImageBrush background = new ImageBrush(){ImageSource = new BitmapImage(new Uri(@"\Assets\Images\MainBackground.jpg", UriKind.Relative))};
            LayoutRoot.Background = background;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            txtNewGreeting.FontFamily = fontFamily;
            txtTemplates.FontFamily = fontFamily;
            txtRecentlySent.FontFamily = fontFamily;
            txtSavedGreetings.FontFamily = fontFamily;
            RunAsync();
        }

        private void btnTemplates_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/TemplateListPage.xaml", UriKind.Relative));
            NavigationService.Navigate(new Uri("/TemplateListPage.xaml", UriKind.Relative));
            //NavigationService.RemoveBackEntry();
            App.Current.TemplateImages = convertImageStringsToImageList(templateImagesStrings);
            App.Current.objectImages = convertImageStringsToImageList(objectImageStrings);
        }

        private List<Image> convertImageStringsToImageList(List<string> images)
        {
            List<Image> lstImages = new List<Image>();
            foreach (var img in images)
            {
                Image i = new Image();
                i.Source = base64image(img);
                lstImages.Add(i);
            }
            return lstImages;
        }

        public static BitmapImage base64image(string base64string)
        {
            //Found this method that converts the base64 string back to a Bitmap Image at: http://stackoverflow.com/questions/14539005/convert-base64-string-to-image-in-c-sharp-on-windows-phone
            byte[] fileBytes = Convert.FromBase64String(base64string);

            using (MemoryStream ms = new MemoryStream(fileBytes, 0, fileBytes.Length))
            {
                ms.Write(fileBytes, 0, fileBytes.Length);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(ms);
                return bitmapImage;
            }
        }

        private void btnNewGreeting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }

        private void btnSavedGreetings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

        private void btnRecentlySent_Click(object sender, RoutedEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //Do your work here
            base.OnBackKeyPress(e);
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }
        

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://egreetings.me/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/Values");
                if (response.IsSuccessStatusCode)
                {
                    List<List<string>> images = await response.Content.ReadAsAsync<List<List<string>>>();
                    MessageBox.Show("Images Loaded!");
                    templateImagesStrings = images[0];
                    objectImageStrings = images[1];
                }
            }
        }
    }
}