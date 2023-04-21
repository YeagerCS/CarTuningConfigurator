using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

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
        private bool isUpdate = false;                                                                                                 
        private Regex regex = new Regex("^[a-zA-Z0-9_.-äöü]+\\s[a-zA-Z0-9_.-äöü]+(\\s[a-zA-Z0-9_.-äöü]+)?$");                                   
                                                                                                                                       
                                                                                                                                       
        public CTCView()                                                                                                               
        {                                                                                                                              
            InitializeComponent();                                                                                                     
            ResizeMode = ResizeMode.NoResize;                                                                                          
        }                                                                                                                              
                                                                                                                                       
        private void Button_Click(object sender, RoutedEventArgs e)                                                                    
        {
            if (isUpdate)
            {
                if (regex.IsMatch(lblBrandModel.Text) && lblBrandModel.Text.Length <= 30)
                {
                    carF.Brand = lblBrandModel.Text.Split(' ')[0];
                    carF.Model = lblBrandModel.Text.Split(' ').Length > 2 ? lblBrandModel.Text.Split(' ')[1] + " " + lblBrandModel.Text.Split(' ')[2] : lblBrandModel.Text.Split(' ')[1];

                    controller.UpdateDatabase(carF);
                    controller.ShowMessageWindow("Success", "Successfully Updated", fontsize: 25);
                    HomeView homeview = new HomeView();
                    homeview.Show();
                    this.Close();
                }
                else
                {
                    controller.ShowMessageWindow("Invalid brand and model name", "Please enter a valid brand and model name ('Brand Model') or ('Brand ModelPart1 Part2), max. 30 symbols", fontsize: 18, backgroundColor: "OrangeRed");
                }
                
            }
            else
            {

                if (regex.IsMatch(lblBrandModel.Text) && lblBrandModel.Text.Length <= 30)
                {
                    carF.Brand = lblBrandModel.Text.Split(' ')[0];
                    carF.Model = lblBrandModel.Text.Split(' ').Length > 2 ? lblBrandModel.Text.Split(' ')[1] + " " + lblBrandModel.Text.Split(' ')[2] : lblBrandModel.Text.Split(' ')[1];
                    controller.SaveToDatabase(carF);
                    controller.ShowMessageWindow("Success", "Successfully Inserted", fontsize: 25);
                    HomeView homeview = new HomeView();
                    homeview.Show();
                    this.Close();
                }
                else
                {
                    controller.ShowMessageWindow("Invalid brand and model name", "Please enter a valid brand and model name ('Brand Model'), max. 10 symbols for each", fontsize: 20, backgroundColor: "OrangeRed");
                }
                
            }
        }


        public CTCView(string path, Car car, string carBrand, string carModel, bool updating)
        {
            InitializeComponent();
            controller = new CTCController();
            carF = car;
            if (carF.Hp == 0)
            {
                carF.Hp = controller.GetDefaultCarModel(carF.Brand).Hp;
            }
            Uri uri = new Uri(path, UriKind.Relative);
            BitmapImage imageBItmap = new BitmapImage(uri);
            selectedCarImage.Source = imageBItmap;
            lblBrandModel.Text = carBrand + " " + carModel;
            Label[] labels = { lblRims, lblSpoiler, lblNitro, lblEngine, lblBreak, lblExhaust, lblTyres };

            controller.ModifyLabels(ref labels, carF);
            DefineStats();
            isUpdate = updating;

            lblPrice.Content += $"{Math.Round(carF.Price, 2)}$";
            if (isUpdate)
            {
                lblPrice.Content = $"Value: {Math.Round(carF.Price, 2)}$";
            }


            InitializeColor();
            FillListBox(stats);
        }

        public void DefineStats()
        {
            stats[0] = $"Topspeed: {carF.TopSpeed} km/h";
            stats[1] = $"Braking force: {carF.BreakingForce} N";
            stats[2] = $"Acceleration: {Math.Round(carF.Acceleration, 2)}s";
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

            lblPrice.Content = !isUpdate ? $"Price: {Math.Round(carF.Price, 2)}$" : $"Value: {Math.Round(carF.Price, 2)}$";


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
            HomeView window = new HomeView();
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            window.DataChanged += Window_DataChanged;
        }


        private void Window_DataChanged(object? sender, (TuningItem? item, string type) e)
        {
            BrushConverter converter = new BrushConverter();
            Car previousCar = (Car)carF.Clone();
            carF = controller.ApplyTuningItemToCar(e.item, carF, e.type);
            object[] elems = controller.CalculatePriceAndStats(carF);
            carF = (Car) elems[1];
            carF.Acceleration = carF.Acceleration < 0.6 ? 0.6 : carF.Acceleration;
            double price = (double) elems[0];
            carF.Price = Math.Round(price, 2);
            Label[] labels = { lblRims, lblSpoiler, lblNitro, lblEngine, lblBreak, lblExhaust, lblTyres };
            Label[] modifiedLables = { lblTopspeed, lblBreakingForce, lblAcceleration, lblNitroPower, lblHorsePower };
            

            

            string[] statImprovement = controller.SetAdditionalLabels(previousCar, carF);

            int j = 0;
            foreach(Label lbl in modifiedLables)
            {
                lbl.Content = statImprovement[j];
                if (statImprovement[j].StartsWith("+") && j != 2)
                {
                    lbl.Foreground = (Brush) converter.ConvertFromString("Green");
                } 
                else if(j == 2)
                {
                    if (statImprovement[j].StartsWith("+"))
                    {
                        lbl.Foreground = (Brush)converter.ConvertFromString("Red");
                    }
                    else
                    {
                        lbl.Foreground = (Brush)converter.ConvertFromString("Green");
                    }
                }
                else
                {
                    lbl.Foreground = (Brush)converter.ConvertFromString("Red");
                }
                j++;
            }

            if(carF.Hp == 0)
            {
                carF.Hp = controller.GetDefaultCarModel(carF.Brand).Hp;
            }

            controller.ModifyLabels(ref labels, carF);
            DefineStats();
            FillListBox(stats);
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
           controller.ShowMessageWindow("Stat Infos", " Topspeed in km/h\n Average Breaking force in N for 5s\n Acceleration in Time for 0-100km/h\n Nitro in Power\n HP in Horsepower", fontsize: 16, backgroundColor: "White", color: "Black");
        }

        private void InitializeColor()
        {
            BrushConverter converter = new BrushConverter();

            plyColor.Fill = (Brush)converter.ConvertFromString(carF.Color);
        }

        private void Polygon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Window dialog = new Window();

            string json = File.ReadAllText("colors.json");

            List<string> colors = JsonSerializer.Deserialize<List<string>>(json);

            ListBox listbox = new ListBox();
            foreach(string color in colors)
            {
                listbox.Items.Add(color);
            }
            listbox.FontSize = 14;
            listbox.Name = "lbxColor";


            Button button = new Button();
            button.Content = "Select Color";
            button.Height = 35;
            button.Width = 130;
            button.VerticalAlignment = VerticalAlignment.Bottom;
            button.Click += SelectColor_Click;


            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.Children.Add(listbox);
            grid.Children.Add(button);
            Grid.SetColumn(listbox, 0);
            Grid.SetColumn(button, 1);
            grid.Background = (Brush)converter.ConvertFromString(carF.Color);

            listbox.SelectionChanged += Listbox_SelectionChanged;


            dialog.Content = grid;

            dialog.Title = "Choose Color";
            dialog.Width = 600;
            dialog.Height = 340;
            dialog.ResizeMode = ResizeMode.NoResize;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            dialog.ShowDialog();

            

            void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                grid.Background = (Brush)converter.ConvertFromString(listbox.SelectedItem.ToString());
            }

            void SelectColor_Click(object sender, RoutedEventArgs e)
            {
                carF.Color = listbox.SelectedItem.ToString();
                dialog.Close();
                InitializeColor();
            }

        }

        
    }
}
