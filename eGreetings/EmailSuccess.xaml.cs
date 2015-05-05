using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace eGreetings
{
    public partial class EmailSuccess : PhoneApplicationPage
    {
        public EmailSuccess()
        {
            InitializeComponent();
            LayoutRoot.Background = App.Current.appBackgroundImage;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            txtSuccess.FontFamily = fontFamily;
            btnOk.FontFamily = fontFamily;
            txtSuccess.FontSize = 48;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}