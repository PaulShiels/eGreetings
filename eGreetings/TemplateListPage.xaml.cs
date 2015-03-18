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
            //if (App.Current.TemplateImages.Count < 11)
            //{                
            //    Image postcard1 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\Postcard1.jpg", UriKind.Relative)), Margin = new Thickness(20, 20, 20, 50) };
            //    Image SeasonGreetings2 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\SeasonGreetings2.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    Image SeasonGreetings3 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\SeasonGreetings3.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    //Image postcard2 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\Postcard1.jpg", UriKind.Relative)), Margin = new Thickness(20, 20, 20, 50) };
            //    //Image SeasonGreetings4 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\SeasonGreetings2.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    //Image SeasonGreetings5 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\SeasonGreetings3.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    //Image postcard3 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\Postcard1.jpg", UriKind.Relative)), Margin = new Thickness(20, 20, 20, 50) };
            //    //Image SeasonGreetings6 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\SeasonGreetings2.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    //Image SeasonGreetings7 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\SeasonGreetings3.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    //Image postcard4 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\Postcard1.jpg", UriKind.Relative)), Margin = new Thickness(20, 20, 20, 50) };
            //    //Image SeasonGreetings8 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\SeasonGreetings2.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    //Image SeasonGreetings9 = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\SeasonGreetings3.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    Image SeasonGreetings = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\seasons_greetings.jpg", UriKind.Relative)), Margin = new Thickness(20, 0, 20, 50) };
            //    App.Current.TemplateImages.Add(postcard1);
            //    //App.Current.TemplateImages.Add(postcard2);
            //    //App.Current.TemplateImages.Add(postcard3);
            //    //App.Current.TemplateImages.Add(postcard4);
            //    App.Current.TemplateImages.Add(SeasonGreetings2);
            //    //App.Current.TemplateImages.Add(SeasonGreetings3);
            //    //App.Current.TemplateImages.Add(SeasonGreetings4);
            //    //App.Current.TemplateImages.Add(SeasonGreetings6);
            //    //App.Current.TemplateImages.Add(SeasonGreetings7);
            //    //App.Current.TemplateImages.Add(SeasonGreetings8);
            //    //App.Current.TemplateImages.Add(SeasonGreetings9);
            //    App.Current.TemplateImages.Add(SeasonGreetings);
            //}
            if (lbxTemplates.Items.Count == 0)
            {
                lbxTemplates.Items.Clear();
                foreach (var image in App.Current.TemplateImages)
                {
                    if (image.Parent != null)
                        ((ListBox)image.Parent).Items.Remove(image);
                    lbxTemplates.Items.Add(image);
                }
            }
            //App.Current.TemplateImages.Clear();
        }

        private void lbxTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
                App.Current.selectedImage = (Image)((ListBox)sender).SelectedItem;
            NavigationService.Navigate(new Uri("/EditingPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //Do your work here
            base.OnBackKeyPress(e);
            NavigationService.Navigate(new Uri(String.Format("/MainPage.xaml", Guid.NewGuid().ToString()), UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }
    }
}