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
        public event EventHandler<(Dictionary<string, double> impacts, TuningItem? item, string type)> DataChanged;
        Dictionary<string, int> impacts;
        CTCController ctcController;

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
            impacts = new Dictionary<string, int>();
            ctcController = new CTCController();
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
                    lblHp.Content += "" + engines[index].ImpactHorsePower;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var impacts = new Dictionary<string, double>();
            int index = lbxSpecs.SelectedIndex;
            if(index != -1)
            {
                switch (current)
                {
                    case "Breaks":
                        List<Break> breaks = TuningItems.Cast<Break>().ToList();
                        impacts["ImpactBreakingForce"] = breaks[index].ImpactBreakingForce;
                        impacts["Price"] = breaks[index].Price;
                        break;
                    case "Nitros":
                        List<Nitro> nitros = TuningItems.Cast<Nitro>().ToList();
                        impacts["ImpactNitro"] = nitros[index].ImpactNitro;
                        impacts["Price"] = nitros[index].Price;
                        break;
                    case "Engines":
                        List<Engine> engines = TuningItems.Cast<Engine>().ToList();
                        impacts["ImpactAcceleration"] = engines[index].ImpactAcceleration;
                        impacts["ImpactHorsePower"] = engines[index].ImpactHorsePower;
                        impacts["ImpactVelocity"] = engines[index].ImpactVelocity;
                        impacts["Price"] = engines[index].Price;
                        break;
                    case "Tyres":
                        List<Tyres> tyres = TuningItems.Cast<Tyres>().ToList();
                        impacts["ImpactAcceleration"] = tyres[index].ImpactAcceleration;
                        impacts["ImpactBreakingForce"] = tyres[index].ImpactBreakingForce;
                        impacts["Price"] = tyres[index].Price;
                        break;
                    case "Exhausts":
                        List<Exhaust> exhausts = TuningItems.Cast<Exhaust>().ToList();
                        impacts["ImpactNitro"] = exhausts[index].ImpactNitro;
                        impacts["Price"] = exhausts[index].Price;
                        break;
                    case "Spoilers":
                        List<Spoiler> spoiler = TuningItems.Cast<Spoiler>().ToList();
                        impacts["ImpactVelocity"] = spoiler[index].ImpactVelocity;
                        impacts["Price"] = spoiler[index].Price;
                        break;
                    case "Rims":
                        break;
                    default:
                        throw new ArgumentException(current + " is not a valid argument");

                    
                }
                DataChanged?.Invoke(this, (impacts, TuningItems[index], current));
            }
            else
            {
                ctcController.ShowMessageWindow("Error", "Please choose an item", fontsize: 22, backgroundColor: "OrangeRed");
            }
        }
    }
    
}
