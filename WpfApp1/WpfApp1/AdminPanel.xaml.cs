using EntityFramework.Models;
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
using WpfApp1;

namespace PoliceApp
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }


        private void Button_Click_Radiowozy(object sender, RoutedEventArgs e)
        {
            AdminPages.Content = new RadiowozyPage();
        }

        private void Button_Click_Policjanci(object sender, RoutedEventArgs e)
        {
            AdminPages.Content = new PolicjanciPage();
        }

        private void Button_Click_Komisariaty(object sender, RoutedEventArgs e)
        {
            AdminPages.Content = new KomisariatyPage();
        }
    }
}
