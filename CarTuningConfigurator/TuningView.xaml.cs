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
        public TuningView()
        {
            InitializeComponent();
        }

        public TuningView(string item)
        {
            InitializeComponent();

            lblTitle.Content = item;
        }
    }
}
