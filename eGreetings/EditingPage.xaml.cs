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
using System.IO;
using System.Windows.Media;
using Microsoft.Phone.Tasks;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Shapes;
using Windows.Phone.UI.Input;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;

namespace eGreetings
{
    public partial class EditingPage : PhoneApplicationPage
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public static Image imageToEdit = new Image();
        private int tickCounter = 0;
        private int objectSelectionTickCounter;
        private bool DisplayImageSavedText;
        private Point currentPoint;
        private Point oldPoint;
        private int drawingStrokeThickness = 9;
        private Color drawingStrokeColour = Colors.White;
        private bool eraserSelected;
        private bool penSelected;
        private WriteableBitmap wb;
        private bool imageSaved=false;

        //Create the grid to hold the objects
        Grid objectsGrid = new Grid();

        public EditingPage()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 75);//Allows 150 milliseconds to click an object
            timer.Tick += timer_Tick;
            canvasImage.Width = Application.Current.Host.Content.ActualHeight;
            canvasImage.Height = Application.Current.Host.Content.ActualWidth;
            //App.Current.editingPage = this;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (objectsGrid.Children.Count == 0)
            {
                imgBackgroundImage.Source = imageToEdit.Source;
                populateObjectsListbox();
            }
            App.Current.imageToSend = null;
        }

        private void populateObjectsListbox()
        {
            //Add 5 columns
            for (int i = 0; i < 5; i++)
            {
                objectsGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            //Create appropriate number of rows
            double rowsNeeded = App.Current.objectImages.Count / 5;
            if (App.Current.objectImages.Count % 5 > 0)
            {
                if (App.Current.objectImages.Count % 5 < 5)
                    rowsNeeded = Math.Round(rowsNeeded, MidpointRounding.ToEven) + 1;
                else
                    rowsNeeded = Math.Round(rowsNeeded, MidpointRounding.AwayFromZero);
            }
            //double rowsNeeded = Math.Round(Convert.ToDouble(App.Current.objectImages.Count / 5), MidpointRounding.AwayFromZero);
            for (int i = 0; i < rowsNeeded; i++)
            {
                objectsGrid.RowDefinitions.Add(new RowDefinition());
            }

            int colId = 0, rowId = 0;
            foreach (var image in App.Current.objectImages)
            {
                if (image.Parent != null)
                    ((Grid)image.Parent).Children.Remove(image);
                image.Margin = new Thickness(5);
                image.MouseLeftButtonUp += Image_MouseLeftButtonUp;
                objectsGrid.Children.Add(image);
                Grid.SetColumn(image, colId);
                Grid.SetRow(image, rowId);

                if (colId < 4)
                    colId++;
                else
                {
                    colId = 0;
                    rowId++;
                }
            }

            lbxObjects.Items.Add(objectsGrid);            
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
            PrepareImageForSending();
            saveImage();            
        }

        private void PrepareImageForSending()
        {
            //I found the follwing code to convert an image to a base64 string at: http://kodierer.blogspot.ie/2010/12/sending-windows-phone-screenshots-in.html
            // Render the element at the maximum possible size
            ScaleTransform transform = null;
            wb = new WriteableBitmap(canvasImage, transform);
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
        }

        private void saveImage()
        {
            //Save image to local images folder
            //Found this method here: http://www.wolfgang-ziegler.com/blog/saving-an-image-to-the-media-library-on-windows-phone
            string fileName = "eGreetings";
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            // If a file with this name already exists, delete it.
            var tempName = Guid.NewGuid().ToString();
            using (var fileStream = store.CreateFile(tempName))
            {
                // Save the WriteableBitmap into isolated storage as JPEG.
                Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
            }
            using (var fileStream = store.OpenFile(tempName, FileMode.Open, FileAccess.Read))
            {
                // Now, add the JPEG image to the photos library.
                var library = new MediaLibrary();
                var pic = library.SavePicture(fileName, fileStream);
            }

            imageSaved = true;

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
            if (!imageSaved)
            {
                unselectTools();
                spModal.Visibility = Visibility.Visible;
                Canvas.SetZIndex(spModal, 2);
                Canvas.SetZIndex(ContentPanel, 0);
                ContentPanel.Opacity = 0.5;
            }
            else
            {
                NavigationService.Navigate(new Uri("/AddEmailBodyPage.xaml", UriKind.Relative));
                spModal.Visibility = Visibility.Collapsed;
                ContentPanel.Opacity = 1;
            }
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

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            PrepareImageForSending();
            saveImage();
            NavigationService.Navigate(new Uri("/AddEmailBodyPage.xaml", UriKind.Relative));
            spModal.Visibility = Visibility.Collapsed;
            ContentPanel.Opacity = 1;            
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            PrepareImageForSending();
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
                    fontSize = 48;
                    break;
                case 1:
                    fontSize = 60;
                    break;
                case 2:
                    fontSize = 80;
                    break;
                case 3:
                    fontSize = 110;
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

        private void btnNoDontLeavePage_Click(object sender, RoutedEventArgs e)
        {
            spBackModal.Visibility = Visibility.Collapsed;
            ToggleToolsButtons(true);
        }

        private void btnYesGoBack_Click(object sender, RoutedEventArgs e)
        {
            spBackModal.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(new Uri("/TemplateListPage.xaml", UriKind.Relative));
        }

        private void ToggleToolsButtons(bool enabled)
        {
            if (enabled)
                spToolsButtons.IsHitTestVisible = true;
            else
                spToolsButtons.IsHitTestVisible = false;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnBackKeyPress(e);

            if (lbxObjects.Visibility == Visibility.Visible)
            {
                lbxObjects.Visibility = Visibility.Collapsed;
            }
            else
            {
                spBackModal.Visibility = Visibility.Visible;
                ToggleToolsButtons(false);
            }
            //NavigationService.Navigate(new Uri(String.Format("/TemplateListPage.xaml", Guid.NewGuid().ToString()), UriKind.Relative));
            //ContentPanel.Children.RemoveAt(0);
        }

        //public static void SaveToMediaLibrary(this WriteableBitmap wb, string fileName)
        //{
        //    var store = IsolatedStorageFile.GetUserStoreForApplication();
        //    // If a file with this name already exists, delete it.
        //    var tempName = Guid.NewGuid().ToString();
        //    using (var fileStream = store.CreateFile(tempName))
        //    {
        //        // Save the WriteableBitmap into isolated storage as JPEG.
        //        Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
        //    }
        //    using (var fileStream = store.OpenFile(tempName, FileMode.Open, FileAccess.Read))
        //    {
        //        // Now, add the JPEG image to the photos library.
        //        var library = new MediaLibrary();
        //        var pic = library.SavePicture(fileName, fileStream);
        //    }
        //}
    }
}