﻿using System;
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
        CTCModel model = new CTCModel();

        int index = 0;

        public MainWindow()
        {
            InitializeComponent();
            updateImage();
            
        }

        private void updateImage()
        {
            Uri uri = new Uri(model.Cars[index].Image, UriKind.Relative);
            BitmapImage imageBItmap = new BitmapImage(uri);
            selectedCarImage.Source = imageBItmap;
                
            if (index == 0)
            {
                triangleLeft.Visibility = Visibility.Hidden;
            }
            else
            {
                triangleLeft.Visibility = Visibility.Visible;
            }

            if (index == model.Cars.Count - 1)
            {
                triangleRight.Visibility = Visibility.Hidden;
            }
            else
            {
                triangleRight.Visibility = Visibility.Visible;
            }

            lblBrandModel.Content = model.Cars[index].Brand + " " + model.Cars[index].Model;
            lblPrice.Content = $"{model.Cars[index].Price}$";
        }

        private void triangleRight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(index < model.Cars.Count - 1)
            {
                index++;
                updateImage();
            }
        }

        private void triangleLeft_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(index > 0)
            {
                index--;
                updateImage();
            }
            
        }
    }
}
