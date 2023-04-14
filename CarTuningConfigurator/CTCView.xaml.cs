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
        Car carF;
        TuningView window;
        public CTCView()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }






        public CTCView(string path, Car car, string carBrand, string carModel)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            carF = car;
            Uri uri = new Uri(path, UriKind.Relative);
            BitmapImage imageBItmap = new BitmapImage(uri);
            selectedCarImage.Source = imageBItmap;
            lblBrandModel.Content = carBrand + " " + carModel;

            string[] stats = { $"Topspeed: {carF.TopSpeed} kmh", $"Braking force: {carF.BreakingForce}", $"Acceleration: {carF.Acceleration}s", $"Nitro: {carF.Nitro}", $"HP: {carF.Hp}" };

            foreach (string stat in stats)
            {
                lbxStats.Items.Add(stat);
            }
        }
        
        private void btnSpoiler_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Spoilers", carF);

            window.Show();
        }

        private void btnExhaust_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Exhausts", carF);

            window.Show();
        }

        private void btnTyres_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Tyres", carF);

            window.Show();
        }

        private void btnRims_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Rims", carF);

            window.Show();
        }

        private void btnEngine_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Engines", carF);

            window.Show();
        }

        private void btnNitro_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Nitros", carF);

            window.Show();
        }

        private void btnBreaks_Click(object sender, RoutedEventArgs e)
        {
            window = new TuningView("Breaks", carF);

            window.Show();
        }

        private void garageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
