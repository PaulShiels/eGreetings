using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace eGreetings
{
    public partial class TemplateListPage : PhoneApplicationPage
    {
        public TemplateListPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Background = App.Current.appBackgroundImage;
            if (lbxTemplates.Items.Count == 0)
            {
                lbxTemplates.Items.Clear();
                foreach (var image in App.Current.catImages)
                {
                    Border border = new Border() {BorderBrush=new SolidColorBrush(Colors.DarkGray), BorderThickness=new Thickness(4), Margin=new Thickness(40) };
                    if (image.Parent != null)
                        ((Border)image.Parent).Child = null;//.Items.Remove(image);
                        //((Grid)image.Parent).Children.Remove(image);
                    //image.Margin = new Thickness(50);
                    border.Child = image;
                    lbxTemplates.Items.Add(border);
                }
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }

        private void lbxTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
                EditingPage.imageToEdit = (Image)((Border)((ListBox)sender).SelectedItem).Child;
            lbxTemplates.SelectedIndex = -1;
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