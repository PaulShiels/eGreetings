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
using System.Windows.Documents;
using System.Windows.Shapes;

namespace eGreetings
{
    public partial class EditingPage : PhoneApplicationPage
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int tickCounter = 0;
        private int objectSelectionTickCounter;
        private bool DisplayImageSavedText;
        private Point currentPoint;
        private Point oldPoint;
        private int drawingStrokeThickness = 9;
        private Color drawingStrokeColour = Colors.White;
        private bool eraserSelected;
        private bool penSelected;

        public EditingPage()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 75);//Allows 150 milliseconds to click an object
            timer.Tick += timer_Tick;
            canvasImage.Width = Application.Current.Host.Content.ActualHeight;
            canvasImage.Height = Application.Current.Host.Content.ActualWidth;
            //App.Current.editingPage = this;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Timer is used to stop objects being selected when dragging them in the listbox 
            //The user must tap the object and let it go within 150ms
            if (objectSelectionTickCounter >= 2)
            {                
                objectSelectionTickCounter = 0;
            }
            else
            {
                objectSelectionTickCounter++;
            }

            //Fade out the Image Saved Message
            if (DisplayImageSavedText)
                DisplayImageSavedText = false;
            else
            {
                if (txtImagedSaved.Opacity > 0)
                    txtImagedSaved.Opacity -= 0.05;
                else
                {
                    txtImagedSaved.Visibility = Visibility.Collapsed;
                    timer.Stop();
                }
            }

            //Check if any new objects need to be added
            //if (App.Current.objectToAdd != null)
            //    oldImageObject = App.Current.objectToAdd;
            tickCounter++;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {////https://onedrive.live.com/embed?cid=6A2C8AD9912860A4&resid=6A2C8AD9912860A4%2146903&authkey=AI-aJjpeVFo5WoQ
            //Image i = new Image() { Source = new BitmapImage(new Uri("https://onedrive.live.com/embed?cid=6A2C8AD9912860A4&resid=6A2C8AD9912860A4%2146903&authkey=AI-aJjpeVFo5WoQ", UriKind.Absolute)) };
            imgBackgroundImage.Source = App.Current.selectedImage.Source;// new BitmapImage(new Uri("http://egreetings.me/eGreetings.me/eGreetingsImages/Backgrounds/SeasonGreetings2.jpg", UriKind.Absolute)); //Source = new BitmapImage(new Uri("https://onedrive.live.com/embed?cid=6A2C8AD9912860A4&resid=6A2C8AD9912860A4%2146903&authkey=AI-aJjpeVFo5WoQ", UriKind.Absolute));// App.Current.selectedImage.Source;
            //imgBackgroundImage.MaxWidth = Application.Current.Host.Content.ActualHeight;
            //imgBackgroundImage.MaxHeight = Application.Current.Host.Content.ActualWidth;

            //List<Image> listBoxImages = new List<Image>();
            //listBoxImages.Add(new Image() { Source = new BitmapImage(new Uri("http://egreetings.me/eGreetings.me/eGreetingsImages/Backgrounds/SeasonGreetings.jpg", UriKind.Absolute)) });
            //listBoxImages.Add(new Image() { Source = new BitmapImage(new Uri("http://egreetings.me/eGreetings.me/eGreetingsImages/Backgrounds/SeasonGreetings1.jpg", UriKind.Absolute)) });
            //listBoxImages.Add(new Image() { Source = new BitmapImage(new Uri("http://egreetings.me/eGreetings.me/eGreetingsImages/Backgrounds/SeasonGreetings2.jpg", UriKind.Absolute)) });
            //listBoxImages.Add(new Image() { Source = new BitmapImage(new Uri("http://egreetings.me/eGreetings.me/eGreetingsImages/Backgrounds/SeasonGreetings3.jpg", UriKind.Absolute)) });
        }

        private void btnObjects_Click(object sender, RoutedEventArgs e)
        {
            unselectTools();
            //Make the list of objects visible
            ContentPanel.Visibility = Visibility.Collapsed;
            lbxObjects.Visibility = Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            unselectTools();
            saveImage();            
        }

        private void saveImage()
        {
            //I found the follwing code to convert an image to a base64 string at: http://kodierer.blogspot.ie/2010/12/sending-windows-phone-screenshots-in.html
            // Render the element at the maximum possible size
            ScaleTransform transform = null;
            //if (canvasImage.ActualWidth * canvasImage.ActualHeight > 240 * 400)
            //{
            //    // Calculate a uniform scale with the minimum possible size
            //    var scaleX = 240.0 / canvasImage.ActualWidth;
            //    var scaleY = 400.0 / canvasImage.ActualHeight;
            //    var scale = scaleX < scaleY ? scaleX : scaleY;
            //    transform = new ScaleTransform { ScaleX = scale, ScaleY = scale };
            //}
            var wb = new WriteableBitmap(canvasImage, transform);
            string imageStringToSave;
            using (var memoryStream = new MemoryStream())
            {
                // Encode the screenshot as JPEG with a quality of 70%
                wb.SaveJpeg(memoryStream, wb.PixelWidth, wb.PixelHeight, 0, 70);
                memoryStream.Seek(0, SeekOrigin.Begin);
               
                // Convert binary data to Base64 string
                var bytes = memoryStream.ToArray();
                App.Current.imageToSend = bytes;
                var base64String = Convert.ToBase64String(bytes);
                imageStringToSave = base64String;
                
                //MessageBox.Show(base64String);
                //byte[] img = Convert.FromBase64String(base64String);

                //imageToSave.Source = base64image(base64String);
                //NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            }
                        

            //Uri address = new Uri("http://egreetings.me");
            //string data = "/api/Values?base64ImageString=" + imageStringToSave;
            //WebClient client = new WebClient();
            //try
            //{
            //    client.UploadStringAsync(address, "POST", data);
            //    client.UploadStringCompleted += client_UploadStringCompleted;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        private void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }

        public static BitmapImage base64image(string base64string)
        {
            //Found this method that converts the base64 string back to a Bitmap Image at: http://stackoverflow.com/questions/14539005/convert-base64-string-to-image-in-c-sharp-on-windows-phone
            byte[] fileBytes = Convert.FromBase64String(base64string);

            using (MemoryStream ms = new MemoryStream(fileBytes, 0, fileBytes.Length))
            {
                ms.Write(fileBytes, 0, fileBytes.Length);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(ms);
                return bitmapImage;
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            unselectTools();
            spModal.Visibility = Visibility.Visible;
            Canvas.SetZIndex(spModal, 2);
            Canvas.SetZIndex(ContentPanel, 0);
            ContentPanel.Opacity=0.5;
        }

        private void btnText_Click(object sender, RoutedEventArgs e)
        {
            unselectTools();
            insertTextModal.Visibility = Visibility.Visible;
        }

        private void btnHideTools_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            spToolsButtons.Visibility = Visibility.Collapsed;
            btnShowTools.Visibility = Visibility.Visible;
        }

        private void btnEraseObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eraserSelected)
            {
                eraserSelected = false;
                btnEraseObject.Background = new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                unselectTools();
                eraserSelected = true;
                btnEraseObject.Background = new SolidColorBrush(Colors.Orange);
            }
        }

        private void btnDraw_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (penSelected)
            {
                penSelected=false;
                btnDraw.Background = new SolidColorBrush(Colors.DarkGray);
                cpDrawColour.Visibility = Visibility.Collapsed;
            }
            else
            {
                unselectTools();
                penSelected = true;
                btnDraw.Background = new SolidColorBrush(Colors.Orange);
                cpDrawColour.Visibility = Visibility.Visible;
            }
        }

        private void btnShowTools_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            spToolsButtons.Visibility = Visibility.Visible;
            btnShowTools.Visibility = Visibility.Collapsed;
        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Stop the timer
            //Check did the user click and image or were they scrolling
            //Get the clicked image
            //Show the editing view again
            timer.Stop();
            if (objectSelectionTickCounter < 1)
            {
                Image i = new Image();
                i.MaxHeight = 120;
                i.MaxWidth = 120;
                i.Source = ((Image)sender).Source;
                i.MouseLeftButtonDown += deleteObject_MouseLeftButtonDown;
                //MessageBox.Show(i.Name);
                ContentPanel.Visibility = Visibility.Visible;
                lbxObjects.Visibility = Visibility.Collapsed;

                //Found this method of allowing the image to be draggable here: http://blogs.msdn.com/b/pakistan/archive/2013/07/10/drag-amp-drop-in-silverlight-for-windows-phone.aspx
                i.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(OnManipulationDelta);                
                canvasImage.Children.Add(i);
                Canvas.SetLeft(i, Application.Current.Host.Content.ActualWidth / 2);
                Canvas.SetTop(i, Application.Current.Host.Content.ActualHeight / 4);
            }
            objectSelectionTickCounter = 0;
        }

        void deleteObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eraserSelected)
            {
                UIElement selectedItem = ((UIElement)sender);
                if (selectedItem is Line)
                {
                    canvasImage.Children.Remove(selectedItem);
                }
                else
                    canvasImage.Children.Remove(selectedItem);
            }
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

        private void btnAddText(object sender, RoutedEventArgs e)
        {
            int fontSize = 0;
            FontFamily fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
            switch (lpFontSize.SelectedIndex)
            {
                case 0:
                    fontSize = 28;
                    break;
                case 1:
                    fontSize = 42;
                    break;
                case 2:
                    fontSize = 64;
                    break;
                case 3:
                    fontSize = 86;
                    break;
            }

            switch (lpFontFamily.SelectedIndex)
            {
                case 0:
                    fontFamily = new FontFamily("/Assets/Fonts/Cucrl.ttf#Curly Coryphaeus");
                    break;
                case 1:
                    fontFamily = new FontFamily("/Assets/Fonts/Dancing Script.ttf#Dancing Script");
                    break;
                case 2:
                    fontFamily = new FontFamily("/Assets/Fonts/konstytucyja_091.ttf#konstytucyja");
                    break;
                case 3:
                    fontFamily = new FontFamily("/Assets/Fonts/Rostock Kaligraph.ttf#Rostock Kaligraph");
                    break;
            }

            TextBlock txtNew = new TextBlock() { Text = txtMessage.Text, FontSize = fontSize, Foreground = new SolidColorBrush(csFontColor.Color), FontFamily = fontFamily };
            txtNew.MouseLeftButtonDown += deleteObject_MouseLeftButtonDown;
            insertTextModal.Visibility = Visibility.Collapsed;
            txtNew.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(OnManipulationDelta); 
            canvasImage.Children.Add(txtNew);
            Canvas.SetLeft(txtNew, Application.Current.Host.Content.ActualWidth / 2);
            Canvas.SetTop(txtNew, Application.Current.Host.Content.ActualHeight / 4);
        }

        private void lpFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtMessage != null)
            {
                string fontName = (((ListPicker)sender).SelectedItem as ListPickerItem).Content.ToString();
                FontFamily font = new FontFamily(fontName);
                //txtMessage.FontFamily = font;
            }
        }

        private void canvasImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Code for drawing found here: http://www.geekchamp.com/tips/drawing-in-wp7-2-drawing-shapes-with-finger
            currentPoint = e.GetPosition(canvasImage);
            oldPoint = currentPoint;
        }

        private void canvasImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (penSelected)
            {
                currentPoint = e.GetPosition(this.canvasImage);
                
                Line line = new Line() { X1 = currentPoint.X, Y1 = currentPoint.Y, X2 = oldPoint.X, Y2 = oldPoint.Y };
                line.Stroke = new SolidColorBrush(drawingStrokeColour);
                line.StrokeThickness = drawingStrokeThickness;
                line.MouseEnter += line_MouseEnter; //deleteObject_MouseLeftButtonDown;
                this.canvasImage.Children.Add(line);
                oldPoint = currentPoint;
            }
        }

        void line_MouseEnter(object sender, MouseEventArgs e)
        {
            if (eraserSelected)
            {
                UIElement selectedItem = ((UIElement)sender);
                if (selectedItem is Line)
                {
                    canvasImage.Children.Remove(selectedItem);
                }
            }
        }
                
        private void unselectTools()
        {
            eraserSelected = false;
            penSelected = false;
            btnDraw.Background = new SolidColorBrush(Colors.DarkGray);
            btnEraseObject.Background = new SolidColorBrush(Colors.DarkGray);
            cpDrawColour.Visibility = Visibility.Collapsed;
        }

        private void cpDrawColour_ColorChanged(object sender, Color color)
        {
            drawingStrokeColour = ((Coding4Fun.Toolkit.Controls.ColorSlider)sender).Color;
        }
    }
}