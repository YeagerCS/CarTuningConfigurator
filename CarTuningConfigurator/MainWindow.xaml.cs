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
        string[] files = { "car1.jpg", "car2.jpg", "car3.jpg", "car4.jpg" };
        int index = 0;

        public MainWindow()
        {
            InitializeComponent();
            updateImage();

            if (index == 0)
            {
                triangleLeft.Visibility = Visibility.Hidden;
            }
            else
            {
                triangleLeft.Visibility= Visibility.Visible;
            }
        }

        private void updateImage()
        {
            Uri uri = new Uri(files[index], UriKind.Relative);
            BitmapImage imageBItmap = new BitmapImage(uri);
            selectedCarImage.Source = imageBItmap;
        }

        private void triangleRight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            index++;
            updateImage();
        }

        private void triangleLeft_MouseDown(object sender, MouseButtonEventArgs e)
        {
            index--;
            updateImage();
        }
    }
}
