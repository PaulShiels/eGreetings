using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Controls.Primitives;
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace eGreetings.Assets
{
    public partial class ObjectsGridPage : PhoneApplicationPage
    {
        private DispatcherTimer timer = new DispatcherTimer();
        int tickCounter = 0;
        public ObjectsGridPage()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 150);//Allows 150 milliseconds to click an object
            timer.Tick += timer_Tick;
            App.Current.objectsPage = this;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            tickCounter++;
        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            timer.Stop();
            if (tickCounter < 1)
            {
                Image i = (Image)sender;
                //MessageBox.Show(i.Name);
                App.Current.objectToAdd.Source = i.Source;
                this.Visibility = Visibility.Collapsed;
                App.Current.editingPage.Visibility = Visibility.Visible;
            }
            tickCounter = 0;
        }

        private void ContentPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            timer.Start();
        }
    }
}