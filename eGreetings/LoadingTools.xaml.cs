using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace eGreetings
{
    public partial class LoadingTools : PhoneApplicationPage
    {
        public LoadingTools()
        {
            InitializeComponent();
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.Current.objectImages.Count==0)
            {
                await App.Current.GetImagesAsync("objects", "all");
                App.Current.objectImages = App.Current.convertImageStringsToImageList(App.Current.retrivedImageStringsTemp);
                App.Current.retrivedImageStringsTemp.Clear();                
            }
            NavigationService.Navigate(new Uri("/EditingPage.xaml", UriKind.Relative));
        }
    }
}