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
        private int TotalImpactVelocity = 0;
        private int TotalImpactAcceleration = 0;
        private int TotalImpactBreakingForce = 0;
        private int TotalImpactHorsePower = 0;
        private int TotalImpactNitro = 0;

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

            DefineStats();
            lblPrice.Content += $"{carF.Price}$";

            FillListBox(stats);
        }

        public void DefineStats()
        {
            stats[0] = $"Topspeed: {carF.TopSpeed} kmh";
            stats[1] = $"Braking force: {carF.BreakingForce}";
            stats[2] = $"Acceleration: {carF.Acceleration}s";
            stats[3] = $"Nitro: {carF.Nitro}";
            stats[4] = $"HP: {carF.Hp}";
        }

        public void FillListBox(string[] stats)
        {
            lbxStats.Items.Clear();

            foreach (string stat in stats)
            {
                lbxStats.Items.Add(stat);
            }

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
            List<TuningItem> items = new List<TuningItem>();

            switch (e.type)
            {
                case "Breaks":
                    if(carF.Break == null)
                    {
                        carF.Break = e.item as Break;
                        TotalImpactBreakingForce += (int)e.impacts["ImpactBreakingForce"];
                        stats[1] += $"+ {TotalImpactBreakingForce}";
                    }
                    else
                    {
                        DefineStats();
                        carF.Break = e.item as Break;
                        TotalImpactBreakingForce -= carF.Break.ImpactBreakingForce;
                        TotalImpactBreakingForce += (int)e.impacts["ImpactBreakingForce"];
                        stats[1] += $"+ {TotalImpactBreakingForce}";
                    }
                    break;
                case "Nitros":
                    if(carF.Nitro == null)
                    {
                        carF.Nitro = e.item as Nitro;
                        TotalImpactNitro += (int)e.impacts["ImpactNitro"];
                        stats[3] += $"+ {TotalImpactNitro}";
                    }
                    else
                    {
                        DefineStats();
                        carF.Nitro = e.item as Nitro;
                        TotalImpactNitro -= carF.Nitro.ImpactNitro;
                        TotalImpactNitro += (int)e.impacts["ImpactNitro"];
                        stats[3] += $"+ {TotalImpactNitro}";
                    }
                    break;
                case "Engines":
                    if(carF.Engine == null)
                    {
                        carF.Engine = e.item as Engine;
                        TotalImpactAcceleration += (int)e.impacts["ImpactAcceleration"];
                        stats[2] += $"- {TotalImpactAcceleration}";

                        TotalImpactHorsePower += (int)e.impacts["ImpactHorsePower"];
                        stats[4] += $"+ {TotalImpactHorsePower}";

                        TotalImpactVelocity += (int)e.impacts["ImpactVelocity"];
                        stats[0] += $"+ {TotalImpactVelocity}";
                    }
                    else
                    {
                        DefineStats();
                        carF.Engine = e.item as Engine;
                        TotalImpactAcceleration -= carF.Engine.ImpactAcceleration;
                        TotalImpactAcceleration += (int)e.impacts["ImpactAcceleration"];
                        stats[2] += $"- {TotalImpactAcceleration}";

                        TotalImpactHorsePower -= carF.Engine.ImpactHorsePower;
                        TotalImpactHorsePower += (int)e.impacts["ImpactHorsePower"];
                        stats[4] += $"+ {TotalImpactHorsePower}";

                        TotalImpactVelocity -= carF.Engine.ImpactVelocity;
                        TotalImpactVelocity += (int)e.impacts["ImpactVelocity"];
                        stats[0] += $"+ {TotalImpactVelocity}";
                    }
                    break;
                case "Tyres":
                    if(carF.Tyres == null)
                    {
                        carF.Tyres = e.item as Tyres;
                        TotalImpactBreakingForce += (int)e.impacts["ImpactBreakingForce"];
                        stats[1] += $"+ {TotalImpactBreakingForce}";

                        TotalImpactAcceleration += (int)e.impacts["ImpactAcceleration"];
                        stats[2] += $"- {TotalImpactAcceleration}";
                    }
                    else
                    {
                        DefineStats();
                        carF.Tyres = e.item as Tyres;

                        TotalImpactBreakingForce -= carF.Tyres.ImpactBreakingForce;
                        TotalImpactBreakingForce += (int)e.impacts["ImpactBreakingForce"];
                        stats[1] += $"+ {TotalImpactBreakingForce}";

                        TotalImpactAcceleration -= carF.Tyres.ImpactAcceleration;
                        TotalImpactAcceleration += (int)e.impacts["ImpactAcceleration"];
                        stats[2] += $"- {TotalImpactAcceleration}";
                    }
                    break;
                case "Exhausts":
                    if(carF.Exhaust == null)
                    {
                        carF.Exhaust = e.item as Exhaust;

                        TotalImpactNitro += (int)e.impacts["ImpactNitro"];
                        stats[3] += $"+ {TotalImpactNitro}";
                    }
                    else
                    {
                        carF.Exhaust = e.item as Exhaust;

                        TotalImpactNitro -= carF.Exhaust.ImpactNitro;
                        TotalImpactNitro += (int)e.impacts["ImpactNitro"];
                        stats[3] += $"+ {TotalImpactNitro}";
                    }
                    break;
                case "Spoilers":
                    if(carF.Spoiler == null)
                    {
                        carF.Spoiler = e.item as Spoiler;

                        TotalImpactVelocity += (int)e.impacts["ImpactVelocity"];
                        stats[0] += $"+ {TotalImpactVelocity}";
                    }
                    else
                    {
                        carF.Spoiler = e.item as Spoiler;

                        TotalImpactVelocity -= carF.Spoiler.ImpactVelocity;
                        TotalImpactVelocity += (int)e.impacts["ImpactVelocity"];
                        stats[0] += $"+ {TotalImpactVelocity}";
                    }
                    break;
                case "Rims":
                    if(carF.Rims == null)
                    {
                        carF.Rims = e.item as Rims;
                    }
                    break;
            }

            items.Add(carF.Break);
            items.Add(carF.Spoiler);
            items.Add(carF.Engine);
            items.Add(carF.Nitro);
            items.Add(carF.Tyres);
            items.Add(carF.Rims);
            items.Add(carF.Exhaust);

            lblPrice.Content = $"Price: {carF.Price + CalculatePrice(items)}$";

            items.Add(e.item);

            FillListBox(stats);
        }

        public double CalculatePrice(List<TuningItem> items)
        {
            double totalPrice = 0;
            foreach(TuningItem item in items) 
            {
                if(item != null)
                {
                    totalPrice += item.Price;
                }
            }

            return totalPrice;
        }

    }
}
