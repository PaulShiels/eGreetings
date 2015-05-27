using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ImageTools.IO.Gif;
using System.Windows.Media;

namespace eGreetings
{
    public partial class LoadingTools : PhoneApplicationPage
    {
        public Uri ImageSource { get; set; }

        public LoadingTools()
        {
            InitializeComponent();           
            LayoutRoot.Background = App.Current.appBackgroundImage;
            //ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            //ImageSource = new Uri("http://egreetings.me/Images/loading_Logo.gif", UriKind.Absolute);
            //this.DataContext = this;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            txtLoading.FontFamily = fontFamily;
        }
               

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.Current.objectImages.Count == 0)
            {
                await App.Current.GetImagesAsync("objects", "all");
                App.Current.objectImages = App.Current.convertImageStringsToImageList(App.Current.retrivedImageStringsTemp);
                App.Current.retrivedImageStringsTemp.Clear();
            }
            NavigationService.Navigate(new Uri("/EditingPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnBackKeyPress(e);
            //NavigationService.Navigate(new Uri(String.Format("/TemplateListPage.xaml", Guid.NewGuid().ToString()), UriKind.Relative));
            //ContentPanel.Children.RemoveAt(0);
        }
    }
}