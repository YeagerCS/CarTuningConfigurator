using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarTuningConfigurator
{
    /// <summary>
    /// Interaction logic for CTCView.xaml
    /// </summary>
    public partial class CTCView : Window
    {

        TuningView window;
        public CTCView()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }






        public CTCView(string path)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;

            Uri uri = new Uri(path, UriKind.Relative);
            BitmapImage imageBItmap = new BitmapImage(uri);
            selectedCarImage.Source = imageBItmap;
        }
        
        private void btnSpoiler_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Spoilers");

            window.Show();
        }

        private void btnExhaust_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Exhausts");

            window.Show();
        }

        private void btnTyres_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Tyres");

            window.Show();
        }

        private void btnRims_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Rims");

            window.Show();
        }

        private void btnEngine_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Engines");

            window.Show();
        }

        private void btnNitro_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Nitros");

            window.Show();
        }

        private void btnBreaks_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Breaks");

            window.Show();
        }
    }
}
