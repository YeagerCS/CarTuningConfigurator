using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections;
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
        TuningView window = new TuningView();
        string[] stats = new string[5];
        CTCController controller;

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
            controller = new CTCController();

            DefineStats();
            lblPrice.Content += $"{carF.Price}$";

            FillListBox(stats);
        }

        public void DefineStats()
        {
            stats[0] = $"Topspeed: {carF.TopSpeed} km/h";
            stats[1] = $"Braking force: {carF.BreakingForce}";
            stats[2] = $"Acceleration: {carF.Acceleration}s from 0 to 100km/h";
            stats[3] = $"Nitro: {carF.nitroPower}";
            stats[4] = $"HP: {carF.Hp}";
        }

        public void FillListBox(string[] stats)
        {
            lbxStats.Items.Clear();

            foreach (string stat in stats)
            {
                lbxStats.Items.Add(stat);
            }

            lblPrice.Content = $"Price: {carF.Price}$";

        }

        private void btnSpoiler_Click(object sender, RoutedEventArgs e)
        {
            window.DataChanged -= Window_DataChanged;
            window = new TuningView("Spoilers", carF);
            window.DataChanged += Window_DataChanged;

            window.Show();
        }

        private void btnExhaust_Click(object sender, RoutedEventArgs e)
        {
            window.DataChanged -= Window_DataChanged;
            window = new TuningView("Exhausts", carF);
            window.DataChanged += Window_DataChanged;

            window.Show();
        }

        private void btnTyres_Click(object sender, RoutedEventArgs e)
        {
            window.DataChanged -= Window_DataChanged;
            window = new TuningView("Tyres", carF);
            window.DataChanged += Window_DataChanged;

            window.Show();
        }

        private void btnRims_Click(object sender, RoutedEventArgs e)
        {
            window.DataChanged -= Window_DataChanged;
            window = new TuningView("Rims", carF);
            window.DataChanged += Window_DataChanged;

            window.Show();
        }

        private void btnEngine_Click(object sender, RoutedEventArgs e)
        {
            window.DataChanged -= Window_DataChanged;
            window = new TuningView("Engines", carF);
            window.DataChanged += Window_DataChanged;

            window.Show();
        }

        private void btnNitro_Click(object sender, RoutedEventArgs e)
        {
            window.DataChanged -= Window_DataChanged;
            window = new TuningView("Nitros", carF);
            window.DataChanged += Window_DataChanged;

            window.Show();
        }

        private void btnBreaks_Click(object sender, RoutedEventArgs e)
        {
            window.DataChanged -= Window_DataChanged;
            window = new TuningView("Breaks", carF);
            window.DataChanged += Window_DataChanged;

            window.Show();
        }

        private void garageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            window.DataChanged += Window_DataChanged;
        }


        private void Window_DataChanged(object? sender, (Dictionary<string, double> impacts, TuningItem item, string type) e)
        {
            carF = controller.ApplyTuningItemToCar(e.impacts, e.item, carF);
            object[] elems = controller.CalculatePriceAndStats(carF);
            carF = (Car) elems[1];
            double price = (double) elems[0];
            carF.Price = price;

            DefineStats();
            FillListBox(stats);
        }

        

    }
}
