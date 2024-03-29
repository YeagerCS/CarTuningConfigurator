﻿using System;
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
        Car carF;

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
            carF = car;
        }

        private void lbxSpecs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPrice.Content = "Price: ";
            lblTopSpeed.Content = "Topspeed: ";
            lblNitro.Content = "Nitro: ";
            lblAcceleration.Content = "Acceleration: ";
            lblHp.Content = "HP: ";
            lblBreakingForce.Content = "Braking force: ";


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
                    Car defaultCar = ctcController.GetDefaultCarModel(carF.Image);
                    int newTopSpeed = (carF.TopSpeed - (engines[index].ImpactVelocity + defaultCar.TopSpeed)) * -1;
                    double newAcceleration = (carF.Acceleration - (engines[index].ImpactAcceleration + defaultCar.Acceleration)) * -1;
                    int newHorsePower = (carF.Hp - (engines[index].ImpactHorsePower + defaultCar.Hp)) * -1;

                    lblPrice.Content += engines[index].Price + "$";
                    lblAcceleration.Content += newAcceleration > 0 ? "-" + Math.Round(newAcceleration, 2) : "+" + Math.Round(Math.Abs(newAcceleration), 2);
                    lblHp.Content += newHorsePower > 0 ? "+" + newHorsePower : newHorsePower + "";
                    lblTopSpeed.Content += newTopSpeed > 0 ? "+" + newTopSpeed : newTopSpeed + "";

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
            if (index != -1)
            {
                DataChanged?.Invoke(this, (TuningItems[index], current));
            }
            else
            {
                ctcController.ShowMessageWindow("Error", "Please choose an item", fontsize: 22, backgroundColor: "OrangeRed");
            }
        }

        private void lblInfo_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(lbxSpecs.SelectedIndex != -1)
            {
                TuningItem selectedItem = TuningItems[lbxSpecs.SelectedIndex];
                switch (current)
                {
                    case "Breaks":
                        ctcController.ShowMessageWindow(current, $" Name: {selectedItem.Name}\n Level: {selectedItem.Level}", fontsize: 20, backgroundColor: "White", color: "Black");
                        break;
                    case "Nitros":
                        ctcController.ShowMessageWindow(current, $" Name: {selectedItem.Name}\n Level: {selectedItem.Level}", fontsize: 20, backgroundColor: "White", color: "Black");
                        break;
                    case "Engines":
                        Engine selectedEngine = (Engine)selectedItem;
                        ctcController.ShowMessageWindow(current, $" Name: {selectedEngine.Name}\n Level: {selectedEngine.Level}\n Type(Fuel): {selectedEngine.Type}\n Cylinder: {selectedEngine.Cylinder}", fontsize: 20, backgroundColor: "White", color: "Black");
                        break;
                    case "Tyres":
                        Tyres selectedTyres = (Tyres)selectedItem;
                        ctcController.ShowMessageWindow(current, $" Name: {selectedTyres.Name}\n Level: {selectedTyres.Level}\n Type: {selectedTyres.Type}", fontsize: 20, backgroundColor: "White", color: "Black");
                        break;
                    case "Exhausts":
                        ctcController.ShowMessageWindow(current, $" Name: {selectedItem.Name}\n Level: {selectedItem.Level}", fontsize: 20, backgroundColor: "White", color: "Black");
                        break;
                    case "Spoilers":
                        Spoiler selectedSpoiler = (Spoiler)selectedItem;
                        ctcController.ShowMessageWindow(current, $" Name: {selectedSpoiler.Name}\n Level: {selectedSpoiler.Level}\n Type: {selectedSpoiler.Type}", fontsize: 20, backgroundColor: "White", color: "Black");
                        break;
                    case "Rims":
                        Rims selectedRims = (Rims)selectedItem;
                        ctcController.ShowMessageWindow(current, $" Name: {selectedRims.Name}\n Level: {selectedRims.Level}\n Type: {selectedRims.Type}\n Color: {selectedRims.Color}", fontsize: 20, backgroundColor: "White", color: "Black");
                        break;
                    default:
                        throw new ArgumentException(current + " is not a valid argument");
                }
            }
        }
    }
}
