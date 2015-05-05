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
    public partial class SavedImagesPage : PhoneApplicationPage
    {
        public SavedImagesPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Background = App.Current.appBackgroundImage;
            if (lbxSavedImages.Items.Count == 0)
            {
                //lbxTemplates.Items.Clear();
                foreach (var image in App.Current.savedImages)
                {
                    Border border = new Border() { BorderBrush = new SolidColorBrush(Colors.DarkGray), BorderThickness = new Thickness(4), Margin = new Thickness(40) };
                    Image i = new Image() { Source = image };
                    if (i.Parent != null)
                        ((Border)i.Parent).Child = null;//.Items.Remove(image);
                    //((Grid)image.Parent).Children.Remove(image);
                    //image.Margin = new Thickness(50);
                    border.Child = i;
                    lbxSavedImages.Items.Add(border);
                }
            }
        }

        private void lbxSavedImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
                EditingPage.imageToEdit = (Image)((Border)((ListBox)sender).SelectedItem).Child;
            lbxSavedImages.SelectedIndex = -1;
            NavigationService.Navigate(new Uri("/LoadingTools.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            NavigationService.Navigate(new Uri(String.Format("/MainPage.xaml", Guid.NewGuid().ToString()), UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }

        
    }
}