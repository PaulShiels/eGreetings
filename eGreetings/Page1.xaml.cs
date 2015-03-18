using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace eGreetings
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
            img1.Source = App.Current.savedImage.Source; //new BitmapImage(new Uri("http://icaam.paulshiels.com/images/logoSmall.png", UriKind.Absolute));
            
        }
    }
}