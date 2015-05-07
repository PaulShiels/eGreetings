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

namespace eGreetings
{
    public partial class Loading : PhoneApplicationPage
    {
        public Uri ImageSource { get; set; }
        public static string ButtonClicked;
        public static string Category;

        public Loading()
        {
            InitializeComponent();
            LayoutRoot.Background = App.Current.appBackgroundImage;
            ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            ImageSource = new Uri("http://egreetings.me/Images/loading_Only.gif", UriKind.Absolute);
            this.DataContext = this;
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            await App.Current.GetImagesAsync(ButtonClicked, Category);
            App.Current.catImages = App.Current.convertImageStringsToImageList(App.Current.retrivedImageStringsTemp);
            App.Current.retrivedImageStringsTemp.Clear();
            NavigationService.Navigate(new Uri("/TemplateListPage.xaml", UriKind.Relative));
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