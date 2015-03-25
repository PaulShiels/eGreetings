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
    public partial class AddEmailBodyPage : PhoneApplicationPage
    {
        public AddEmailBodyPage()
        {
            InitializeComponent();
            LayoutRoot.Background = App.Current.appBackgroundImage;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SendPage.xaml", UriKind.Relative));
        }
    }
}