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
using System.Windows.Shapes;

namespace CarTuningConfigurator
{
    /// <summary>
    /// Interaction logic for TuningView.xaml
    /// </summary>
    public partial class TuningView : Window
    {
        List<TuningItem> TuningItems;
        TuningController controller;

        string current = "";
        public TuningView()
        {
            InitializeComponent();
            TuningItems = new List<TuningItem>();
        }

        public TuningView(string item, Car car)
        {
            controller = new TuningController();
            InitializeComponent();
            this.DataContext = this;
            current = item;
            lblTitle.Content = item;
            TuningItems = controller.InsertContent(item);
            controller.AddToListBox(lbxSpecs, TuningItems);
        }

        private void lbxSpecs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPrice.Content = "Price: ";
            lblTopSpeed.Content = "Topspeed: ";
            lblNitro.Content = "Nitro: ";
            lblAcceleration.Content = "Acceleration: ";
            lblHp.Content = "HP: ";
            lblBreakingForce.Content = "Breaking force: ";


            int index = lbxSpecs.SelectedIndex;
            switch (current)
            {
                case "Breaks":
                    List<Break> breaks = TuningItems.Cast<Break>().ToList();
                    lblPrice.Content += breaks[index].Price + "$";
                    lblBreakingForce.Content += "+" + breaks[index].ImpactBreakingForce + "";
                    break;
                case "Nitros":
                    List<Nitro> nitros = TuningItems.Cast<Nitro>().ToList();
                    lblPrice.Content += nitros[index].Price + "$";
                    lblNitro.Content += "+" + nitros[index].ImpactNitro;
                    break;
                case "Engines":
                    List<Engine> engines = TuningItems.Cast<Engine>().ToList();
                    lblPrice.Content += engines[index].Price + "$";
                    lblAcceleration.Content += "-" + engines[index].ImpactAcceleration;
                    lblHp.Content += "+" + engines[index].ImpactHorsePower;
                    lblTopSpeed.Content += "+" + engines[index].ImpactVelocity;
                    break;
                case "Rims":
                    List<Rims> Rims = TuningItems.Cast<Rims>().ToList();
                    lblPrice.Content += Rims[index].Price + "$";
                    break;
                case "Tyres":
                    List<Tyres> tyres = TuningItems.Cast<Tyres>().ToList();
                    lblPrice.Content += tyres[index].Price + "$";
                    lblAcceleration.Content += "-" + tyres[index].ImpactAcceleration;
                    lblBreakingForce.Content += "+" + tyres[index].ImpactBreakingForce;
                    break;
                case "Exhausts":
                    List<Exhaust> exhausts = TuningItems.Cast<Exhaust>().ToList();
                    lblPrice.Content += exhausts[index].Price + "$";
                    lblNitro.Content += "+" + exhausts[index].ImpactNitro;
                    break;
                case "Spoilers":
                    List<Spoiler> spoiler = TuningItems.Cast<Spoiler>().ToList();
                    lblPrice.Content += spoiler[index].Price + "$";
                    lblTopSpeed.Content += "+" + spoiler[index].ImpactVelocity;
                    break;
            }

        }
    }
}
