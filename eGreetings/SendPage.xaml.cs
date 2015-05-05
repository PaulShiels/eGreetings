using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Venetasoft.WP.Net;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.Net.NetworkInformation;
using System.Reflection;
using Windows.Storage;
using System.Windows.Media;

namespace eGreetings
{
    public partial class SendPage : PhoneApplicationPage
    {
        //create a new MailMessage object
        public static MailMessage mailMessage = new MailMessage();

        public SendPage()
        {
            InitializeComponent();
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            txtRecipients.FontFamily = fontFamily;
            txtRecipient.FontFamily = fontFamily;
            btnSend.FontFamily = fontFamily;
            txtRecipients.FontSize = 38;
            txtRecipient.FontSize = 38;
            LayoutRoot.Background = App.Current.appBackgroundImage;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        

        private void mailMessage_Progress(object sender, Venetasoft.WP7.ValueEventArgs<int> e)
        {
            var o = sender;
        }

        private void mailMessage_MailSent(object sender, Venetasoft.WP7.ValueEventArgs<bool> e)
        {
            if (e.Value == false)   //mail not sent         
            {
                string errMsg = mailMessage.ToString();
                //if (errMsg.Contains("Connection lost") == false && errMsg.Contains("Aborted by user") == false)
                    //errMsg += "\r\nLast server response: " + mailMessage.LastServerResponse;

                MessageBox.Show("Error sending mail: " + errMsg + mailMessage.LastServerResponse);

            }
            else
            {
                //MessageBox.Show("Email successfully queued to Microsoft Live mail server.");
                NavigationService.Navigate(new Uri("/EmailSuccess.xaml", UriKind.Relative));
            }            
        }

        private void mailMessage_Error(object sender, Venetasoft.WP7.ErrorEventArgs e)
        {
            MessageBox.Show(e.Value, "Error sending mail", MessageBoxButton.OK);            
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string recipient = txtRecipient.Text;
            //string greetingSender = txtSender.Text;

            //create a new MailMessage object
            MailMessage mailMessage = new MailMessage();

            #region validation checks
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("Network is unavailable.");
                return;
            }
            if (mailMessage != null && mailMessage.Busy == true)
            {
                MessageBox.Show("Pending operation in progress, please wait..");
                return;
            }
            #endregion
            
            //set a Live/Hotmail or Gmail, or a custom SMTP account
            mailMessage.UserName = "egreetingswp@gmail.com";                        // ****@gmail.com, ****@yourserver.com, etc.
            mailMessage.Password = "greetingsfromall";
            mailMessage.AccountType = MailMessage.AccountTypeEnum.Gmail;   //you can set your  CustomSMTP server/port/no-ssl
            //mailMessage.SetCustomSMTPServer("smtp1r.cp.blacknight.com", 587, false);
            mailMessage.From = "egreetingswp@gmail.com";
            //set mail data
            mailMessage.To = txtRecipient.Text;
            mailMessage.Subject = "eGreetings to you";
            mailMessage.Body = "Hello";//App.Current.emailBody;   //text or HTML

            //attach ANY KIND of file from a resource or IsolatedStorage path
            //Image SeasonGreetings = new Image() { Source = new BitmapImage(new Uri("Assets\\Images\\seasons_greetings.jpg", UriKind.Relative)) };
            //BitmapImage b = new BitmapImage(new Uri("Assets\\Images\\seasons_greetings.jpg", UriKind.Relative));
            //FileInfo fi = new FileInfo(App.Current.imageToSend.Source.ToString());//b.UriSource.ToString());
            
            //string image = ((BitmapImage)(App.Current.selectedImage.Source)).UriSource.ToString();
            //string imageName = image.Substring(14, image.Length - 14);
            mailMessage.AddAttachment(App.Current.imageToSend,"Greetings.jpg");

            //attach from in-memory data:
            //mailMessage.AddAttachment(Encoding.UTF8.GetBytes("yesssss".ToCharArray()), "memoryfile.txt");
            //mailMessage.AddAttachment(Encoding.UTF8.GetBytes("yesssss".ToCharArray()), "memoryfile.txt");
            //set message event handlers
            mailMessage.Error += mailMessage_Error;
            mailMessage.MailSent += mailMessage_MailSent;
            mailMessage.Progress += mailMessage_Progress;
            //send email (async)
            mailMessage.Send();
            NavigationService.Navigate(new Uri("/SendingPage.xaml", UriKind.Relative));
            
        }
        
    }
}