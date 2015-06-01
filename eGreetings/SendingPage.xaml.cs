using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ImageTools.IO.Gif;
using System.Windows.Media;

namespace eGreetings
{
    public partial class SendingPage : PhoneApplicationPage
    {
        public Uri ImageSource { get; set; }

        public SendingPage()
        {
            InitializeComponent();                       
            LayoutRoot.Background = App.Current.appBackgroundImage;
            ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            ImageSource = new Uri("http://egreetings.me/Images/newtonsLoading1.gif", UriKind.Absolute);
            this.DataContext = this;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            txtSending.FontFamily = fontFamily;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnBackKeyPress(e);
        }

        
    }
}