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
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;
using System.Collections.ObjectModel;
using System.Collections;
using System.Net.NetworkInformation;
using Microsoft.Phone.Info;
using Microsoft.Phone.Tasks;

namespace eGreetings
{
    public partial class MainPage : PhoneApplicationPage
    {
        //private ObservableCollection<IEnumerable> _pics = new ObservableCollection<IEnumerable>();
        //private static List<string> templateImagesStrings = new List<string>();
        //private static List<string> objectImageStrings = new List<string>();

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            App.Current.appBackgroundImage = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"\Assets\Images\MainBackground.jpg", UriKind.Relative))};
            LayoutRoot.Background = App.Current.appBackgroundImage;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            txtNewGreeting.FontFamily = fontFamily;
            txtTemplates.FontFamily = fontFamily;
            txtRecentlySent.FontFamily = fontFamily;
            txtSavedGreetings.FontFamily = fontFamily;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            //App.Current.selectedImage = new Image() { Source = new BitmapImage(new Uri("http://ww1.prweb.com/prfiles/2014/04/10/11752526/gI_134971_best-image-web-hosting.png", UriKind.Absolute)) };
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (DeviceStatus.DeviceTotalMemory < 268435456)
            {
                MessageBoxResult result = MessageBox.Show("Sorry your device does not contain enough RAM to run eGreetings. \neGreetings will now close.");
                if (result == MessageBoxResult.OK)
                {
                    App.Current.Terminate();
                }
            }

            //RunAsync();
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBoxResult result = MessageBox.Show("A network connection is unavailable therefore eGreetings is unable to run. \neGreetings will now close.");
                if(result == MessageBoxResult.OK)
                {
                    App.Current.Terminate();
                }
            }

            loadString();

            
        }  

        private string loadString()
        {
            string result = null;
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists("Login.store"))
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                    //using (IsolatedStorageFileStream rawStream = isf.OpenFile("Login.store", System.IO.FileMode.Open))
                    //{
                    //    StreamReader reader = new StreamReader(rawStream);
                    //    result = reader.ReadLine();
                    //    reader.Close();
                    //}

                    //If the app has not been rated ask the user to rate it
                    if (isf.FileExists("AppHasBeenUsed.store"))
                    {
                        if (!isf.FileExists("Rated.store"))
                        {
                            MessageBoxResult mbxResult = MessageBox.Show("Please take a minute to tell us what you think of eGreetings", "Tell us what you think", MessageBoxButton.OKCancel);
                            if (mbxResult == MessageBoxResult.OK)
                            {
                                using (IsolatedStorageFileStream rawStream = isf.CreateFile("Rated.store")) { }
                                MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                                marketplaceReviewTask.Show();
                            }
                        }
                        else
                        {
                            //DateTime creationDate = Convert.ToDateTime(isf.GetCreationTime("Rated.store").TimeOfDay.ToString());
                            //if (DateTime.Now.Subtract(creationDate).TotalDays > 4)
                            //{
                            //    isf.DeleteFile("Rated.store");
                            //}
                        }

                    }
                    else
                    {
                        using (IsolatedStorageFileStream rawStream = isf.CreateFile("AppHasBeenUsed.store")) { }
                    }
                }
                else
                {
                    NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
                }
            }
            return result;
        }

        private void btnTemplates_Click(object sender, RoutedEventArgs e)
        {
            Loading.ButtonClicked = "templates";
            //NavigationService.Navigate(new Uri("/TemplateListPage.xaml", UriKind.Relative));
            NavigationService.Navigate(new Uri("/SelectCategory.xaml", UriKind.Relative));
            //NavigationService.RemoveBackEntry();
            //App.Current.TemplateImages = convertImageStringsToImageList(templateImagesStrings);
            //App.Current.objectImages = convertImageStringsToImageList(objectImageStrings);
        }

        private void btnNewGreeting_Click(object sender, RoutedEventArgs e)
        {
            Loading.ButtonClicked = "newGreeting";
            NavigationService.Navigate(new Uri("/SelectCategory.xaml", UriKind.Relative));
        }

        private void btnSavedGreetings_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));

            try
            {
                //http://blogs.msdn.com/b/johnalioto/archive/2011/01/28/10121728.aspx
                // Work around for known bug in the media framework.  Hits the static constructors
                // so the user does not need to go to the picture hub first.
                MediaPlayer.Queue.ToString();

                MediaLibrary ml = null;
                PictureAlbum savedPics = null;

                foreach (MediaSource source in MediaSource.GetAvailableMediaSources())
                {
                    if (source.MediaSourceType == MediaSourceType.LocalDevice)
                    {
                        ml = new MediaLibrary(source);
                        PictureAlbumCollection allAlbums = ml.RootPictureAlbum.Albums;

                        foreach (PictureAlbum album in allAlbums)
                        {
                            if (album.Name == "Saved Pictures")
                            {
                                savedPics = album;
                            }
                        }
                    }
                }

                App.Current.savedImages.Clear();
                foreach (Picture p in savedPics.Pictures)
                {
                    if (p.Name.Contains("eGreetings"))
                    {
                        BitmapImage b = new BitmapImage();
                        b.SetSource(p.GetImage());
                        App.Current.savedImages.Add(b);
                    }
                }
                NavigationService.Navigate(new Uri("/SavedImagesPage.xaml", UriKind.Relative));
            }
            catch
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }


            
        }

        //Found code to use Isolated storage here: http://www.baileystein.com/2014/07/28/saving-bitmapimages-isolatedstorage-windows-phone-8-app/
        //public BitmapImage GetImage(string fname)
        //{
        //    BitmapImage img = new BitmapImage();
        //    try
        //    {
        //        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        //        {
        //            using (IsolatedStorageFileStream fileStream = isf.OpenFile(fname, FileMode.Open, FileAccess.Read))
        //            {
        //                img.SetSource(fileStream);
        //                fileStream.Close();
        //            }
        //        }
        //    }
        //    catch { }

        //    return img;
        //}

        private void btnRecentlySent_Click(object sender, RoutedEventArgs e)
        {

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
            App.Current.Terminate();
            //NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            //NavigationService.RemoveBackEntry();
        }
        
        //static async Task RunAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://egreetings.me/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        // HTTP GET
        //        HttpResponseMessage response = await client.GetAsync("api/Values");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            List<List<string>> images = await response.Content.ReadAsAsync<List<List<string>>>();
        //            MessageBox.Show("Images Loaded!");
        //            templateImagesStrings = images[0];
        //            objectImageStrings = images[1];
        //        }
        //    }
        //}
    }
}