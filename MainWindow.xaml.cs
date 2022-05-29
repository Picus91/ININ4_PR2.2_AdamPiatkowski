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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NET_ININ4_PR2._2_z3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelObliczeń model = new ModelObliczeń();
        public MainWindow()
        {
            DataContext = model;
            InitializeComponent();
        }

        private void Cyfra(object sender, RoutedEventArgs e)
        {
            model.DopiszCyfrę(
                cyfra: (string)((Button)sender).Content
                );
        }

        private void Przecinek(object sender, RoutedEventArgs e)
        {
            model.WstawPrzecinek();
        }

        private void ZmianaZnaku(object sender, RoutedEventArgs e)
        {
            model.ZmianaZnaku();
        }
    }
}
