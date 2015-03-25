using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace eGreetings
{
    public partial class SelectCategory : PhoneApplicationPage
    {
        private static List<string> imageStrings = new List<string>();
        public static string ButtonClicked;

        public SelectCategory()
        {
            InitializeComponent();
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            txtCat.FontFamily = fontFamily;
            lstCats.FontFamily = fontFamily;
            LayoutRoot.Background = App.Current.appBackgroundImage;
            //img1.Source = App.Current.savedImage.Source; //new BitmapImage(new Uri("http://icaam.paulshiels.com/images/logoSmall.png", UriKind.Absolute));
            
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            lstCats.Items.Clear();
            string[] cats = { "Birthday", "Christmas", "Other" };
            foreach (var cat in cats)
            {
                lstCats.Items.Add(cat);
            }
        }

        private async void lstCats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await GetImagesAsync(((ListBox)sender).SelectedValue.ToString());
            App.Current.catImages = convertImageStringsToImageList(imageStrings);
            NavigationService.Navigate(new Uri("/TemplateListPage.xaml", UriKind.Relative));
        }

        static async Task GetImagesAsync(string category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://egreetings.me/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/Values?greetingType=" + ButtonClicked + "&&category=" + category);
                if (response.IsSuccessStatusCode)
                {
                    imageStrings = await response.Content.ReadAsAsync<List<string>>();
                    
                    //List<List<string>> images = await response.Content.ReadAsAsync<List<List<string>>>();
                    //MessageBox.Show("Images Loaded!");
                    //templateImagesStrings = images[0];
                    //objectImageStrings = images[1];
                }
            }
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
    }
}