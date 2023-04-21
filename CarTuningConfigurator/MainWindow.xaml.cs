using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarTuningConfigurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CTCModel model;
        private BrushConverter converter = new BrushConverter();
        bool isConfig = false;
        int index = 0;
        bool isLoaded = false;

        public MainWindow(bool configure)
        {
            model = new CTCModel(true);

            if (model.Cars.Count > 0)
            {
                isLoaded = true;
                isConfig = true;
                Uri uri = new Uri(model.Cars[index].Image, UriKind.Relative);
                BitmapImage imageBItmap = new BitmapImage(uri);

                selectedCarImage.Source = imageBItmap;

                // Update the label and triangle visibility
                if (index == 0)
                {
                    triangleLeft.Visibility = Visibility.Hidden;
                }
                else
                {
                    triangleLeft.Visibility = Visibility.Visible;
                }

                if (index == model.Cars.Count - 1)
                {
                    triangleRight.Visibility = Visibility.Hidden;
                }
                else
                {
                    triangleRight.Visibility = Visibility.Visible;
                }

                lblBrandModel.Content = model.Cars[index].Brand + " " + model.Cars[index].Model;
                lblPrice_Copy.Content = "Value: ";
                lblPrice.Content = model.Cars[index].Price + "$";
                InitializeStatistics();

                plyColor.Fill = (Brush)converter.ConvertFromString(model.Cars[index].Color);
            }
            else
            {
                new CTCController().ShowMessageWindow("No Tuned Cars", "There currently are no tuned cars, go tune some cars", fontsize: 21, backgroundColor: "Orange");
                isLoaded = false;
            }
            
            InitializeComponent();

        }

        public void InitializeStatistics()
        {
            lblHP.Content = model.Cars[index].Hp + "HP";
            lblTopSpeed.Content = model.Cars[index].TopSpeed + "km/h";
            if (model.Cars[index].Engine == null || model.Cars[index].Engine.Name == "Default")
            {
                lblEngineName.Content = "Default";
                lblEngineType.Content = "Default/Gasoline";
                lblEngineCylinder.Content = "Default";
            }
            else
            {
                lblEngineName.Content = model.Cars[index].Engine.Name;
                lblEngineType.Content = model.Cars[index].Engine.Type;
                lblEngineCylinder.Content = model.Cars[index].Engine.Cylinder;
            }
        }
        public MainWindow()
        {
            model = new CTCModel();
            InitializeComponent();
            Uri uri = new Uri(model.Cars[index].Image, UriKind.Relative);
            BitmapImage imageBItmap = new BitmapImage(uri);
            isLoaded = true;
            selectedCarImage.Source = imageBItmap;

            // Update the label and triangle visibility
            if (index == 0)
            {
                triangleLeft.Visibility = Visibility.Hidden;
            }
            else
            {
                triangleLeft.Visibility = Visibility.Visible;
            }

            if (index == model.Cars.Count - 1)
            {
                triangleRight.Visibility = Visibility.Hidden;
            }
            else
            {
                triangleRight.Visibility = Visibility.Visible;
            }

            lblBrandModel.Content = model.Cars[index].Brand + " " + model.Cars[index].Model;
            lblPrice.Content = $"{model.Cars[index].Price}$";

            plyColor.Fill = (Brush)converter.ConvertFromString(model.Cars[index].Color);
        }

        private async void updateImage()
        {
            
            var animation1 = (Storyboard)FindResource("ImageTransitionout");
            animation1.Begin(selectedCarImage);
            await Task.Delay(500);
            
            Uri uri = new Uri(model.Cars[index].Image, UriKind.Relative);
            BitmapImage imageBItmap = new BitmapImage(uri);

            
            var animation2 = (Storyboard)FindResource("ImageTransitionin");
            
            selectedCarImage.Source = imageBItmap;
            animation2.Begin(selectedCarImage);

            // Update the label and triangle visibility
            if (index == 0)
            {
                triangleLeft.Visibility = Visibility.Hidden;
            }
            else
            {
                triangleLeft.Visibility = Visibility.Visible;
            }

            if (index == model.Cars.Count - 1)
            {
                triangleRight.Visibility = Visibility.Hidden;
            }
            else
            {
                triangleRight.Visibility = Visibility.Visible;
            }

            lblBrandModel.Content = model.Cars[index].Brand + " " + model.Cars[index].Model;
            lblPrice.Content = $"{model.Cars[index].Price}$";
        }

        private void triangleRight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(index < model.Cars.Count - 1)
            {
                index++;
                updateImage();
                plyColor.Fill = (Brush)converter.ConvertFromString(model.Cars[index].Color);
                if(isConfig) InitializeStatistics();
            }
        }

        private void triangleLeft_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (index > 0)
            {
                index--;
                updateImage();
                plyColor.Fill = (Brush)converter.ConvertFromString(model.Cars[index].Color);
                if(isConfig) InitializeStatistics();
            }

        }

        private void selectedCarImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CTCView window;
            if (isConfig)
            {
                window = new CTCView(model.Cars[index].Image, model.Cars[index], model.Cars[index].Brand, model.Cars[index].Model, true);
            }
            else
            {
                window = new CTCView(model.Cars[index].Image, model.Cars[index], model.Cars[index].Brand, model.Cars[index].Model, false);
            }
            window.Show();
            var transitionStoryboard = (Storyboard)FindResource("windowTransition");
            transitionStoryboard.Begin(window);
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeView homeView = new HomeView();
            homeView.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                HomeView homeView = new HomeView();
                homeView.Show();
                this.Close();
            }
        }
    }
}
