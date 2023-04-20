using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace CarTuningConfigurator
{
    /// <summary>
    /// Interaction logic for TuningView.xaml
    /// </summary>
    public partial class TuningView : Window
    {
        List<TuningItem> TuningItems;
        TuningController controller;
        public event EventHandler<(TuningItem? item, string type)> DataChanged;
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
            int index = lbxSpecs.SelectedIndex;
            if(index != -1)
            {
                switch (current)
                {
                    case "Breaks":
                        List<Break> breaks = TuningItems.Cast<Break>().ToList();
                        break;
                    case "Nitros":
                        List<Nitro> nitros = TuningItems.Cast<Nitro>().ToList();
                        break;
                    case "Engines":
                        List<Engine> engines = TuningItems.Cast<Engine>().ToList();
                        break;
                    case "Tyres":
                        List<Tyres> tyres = TuningItems.Cast<Tyres>().ToList();
                        break;
                    case "Exhausts":
                        List<Exhaust> exhausts = TuningItems.Cast<Exhaust>().ToList();
                        break;
                    case "Spoilers":
                        List<Spoiler> spoiler = TuningItems.Cast<Spoiler>().ToList();
                        break;
                    case "Rims":
                        break;
                    default:
                        throw new ArgumentException(current + " is not a valid argument");

                    
                }
                DataChanged?.Invoke(this, (TuningItems[index], current));
            }
            else
            {
                ctcController.ShowMessageWindow("Error", "Please choose an item", fontsize: 22, backgroundColor: "OrangeRed");
            }
        }
    }
    
}
