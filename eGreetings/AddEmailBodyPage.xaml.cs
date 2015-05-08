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
    public partial class AddEmailBodyPage : PhoneApplicationPage
    {
        public AddEmailBodyPage()
        {
            InitializeComponent();
            LayoutRoot.Background = App.Current.appBackgroundImage;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            lblAddMsg.FontFamily = fontFamily;
            txtEmailBody.FontFamily = fontFamily;
            btnNext.FontFamily = fontFamily;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            App.Current.emailBody = txtEmailBody.Text;
            NavigationService.Navigate(new Uri("/SendPage.xaml", UriKind.Relative));
        }
    }
}