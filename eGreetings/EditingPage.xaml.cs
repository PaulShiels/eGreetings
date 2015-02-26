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
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Input;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media;
using Microsoft.Phone.Tasks;
using System.Threading.Tasks;

namespace eGreetings
{
    public partial class EditingPage : PhoneApplicationPage
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int tickCounter = 0;
        public EditingPage()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 150);//Allows 150 milliseconds to click an object
            timer.Tick += timer_Tick;
            //App.Current.editingPage = this;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tickCounter++;
            //Check if any new objects need to be added
            //if (App.Current.objectToAdd != null)
            //    oldImageObject = App.Current.objectToAdd;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            imgBackgroundImage.Source = App.Current.selectedImage.Source;
            imgBackgroundImage.MaxWidth = Application.Current.Host.Content.ActualHeight;
            imgBackgroundImage.MaxHeight = Application.Current.Host.Content.ActualWidth;
        }

        private void btnObjects_Click(object sender, RoutedEventArgs e)
        {
            //Make the list of objects visible
            ContentPanel.Visibility = Visibility.Collapsed;
            lbxObjects.Visibility = Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            saveImage();            
        }

        private void saveImage()
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();

            using (IsolatedStorageFileStream isoStream2 = new IsolatedStorageFileStream("new.jpg", FileMode.OpenOrCreate, isoStore))
            {
                WriteableBitmap wbmp = new WriteableBitmap(canvasImage, null);
                wbmp.SaveJpeg(isoStream2, wbmp.PixelWidth, wbmp.PixelHeight, 0, 100);
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            spModal.Visibility = Visibility.Visible;
            Canvas.SetZIndex(spModal, 2);
            Canvas.SetZIndex(ContentPanel, 0);
            ContentPanel.Opacity=0.5;
        }

        private void btnText_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Stop the timer
            //Check did the user click and image or were they scrolling
            //Get the clicked image
            //Show the editing view again
            timer.Stop();
            if (tickCounter < 1)
            {
                Image i = new Image();
                i.MaxHeight = 120;
                i.MaxWidth = 120;
                i.Source = ((Image)sender).Source;
                //MessageBox.Show(i.Name);
                ContentPanel.Visibility = Visibility.Visible;
                lbxObjects.Visibility = Visibility.Collapsed;

                //Found this method of allowing the image to be draggable here: http://blogs.msdn.com/b/pakistan/archive/2013/07/10/drag-amp-drop-in-silverlight-for-windows-phone.aspx
                i.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(OnManipulationDelta);                
                canvasImage.Children.Add(i);
                Canvas.SetLeft(i, Application.Current.Host.Content.ActualWidth / 2);
                Canvas.SetTop(i, Application.Current.Host.Content.ActualHeight / 4);
            }
            tickCounter = 0;
        }

        void OnManipulationDelta(object sender, ManipulationDeltaEventArgs args)
        {
            FrameworkElement Elem = sender as FrameworkElement;

            double Left = Canvas.GetLeft(Elem);
            double Top = Canvas.GetTop(Elem);

            Left += args.DeltaManipulation.Translation.X;
            Top += args.DeltaManipulation.Translation.Y;
            Canvas.SetLeft(Elem, Left);
            Canvas.SetTop(Elem, Top);
        }

        private void lbxObjects_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            timer.Start();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //Do your work here
            base.OnBackKeyPress(e);
            NavigationService.Navigate(new Uri(String.Format("/TemplateListPage.xaml", Guid.NewGuid().ToString()), UriKind.Relative));
            NavigationService.RemoveBackEntry();
            //ContentPanel.Children.RemoveAt(0);
        }
        
        public object NewImgMouseLeftButtonDown { get; set; }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            saveImage();
            NavigationService.Navigate(new Uri("/AddEmailBodyPage.xaml", UriKind.Relative));
            spModal.Visibility = Visibility.Collapsed;
            ContentPanel.Opacity = 1;            
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddEmailBodyPage.xaml", UriKind.Relative));
            spModal.Visibility = Visibility.Collapsed;
            ContentPanel.Opacity = 1;
        }  
    }
}