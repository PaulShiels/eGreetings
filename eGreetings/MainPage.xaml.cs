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

namespace eGreetings
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        private void btnTemplates_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/TemplateListPage.xaml", UriKind.Relative));
            NavigationService.Navigate(new Uri("/TemplateListPage.xaml", UriKind.Relative));
            //NavigationService.RemoveBackEntry();
        }

        private void btnNewGreeting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSavedGreetings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRecentlySent_Click(object sender, RoutedEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //Do your work here
            base.OnBackKeyPress(e);
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }
    }
}