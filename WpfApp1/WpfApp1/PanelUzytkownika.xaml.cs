using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logika interakcji dla klasy PanelUzytkownika.xaml
    /// </summary>
    public partial class PanelUzytkownika : Window
    {
        public PanelUzytkownika()
        {
            InitializeComponent();
        }


        private void Button_Click_Podwladni(object sender, RoutedEventArgs e)
        {
            UserPages.Content = new Podwladni();
        }

        private void Button_Click_Regiony(object sender, RoutedEventArgs e)
        {
            UserPages.Content = new RegionPanel();
        }

        private void Button_Click_Kartoteka(object sender, RoutedEventArgs e)
        {
            UserPages.Content = new KartotekaPage();
        }

        private void Button_Click_Plan(object sender, RoutedEventArgs e)
        {
            UserPages.Content = new PlanCheckPage();
        }

        private void Button_Click_Wykroczenia(object sender, RoutedEventArgs e)
        {

            UserPages.Content = new KartotekaWykroczenie();
        }

        private void Button_Click_Przestepstwa(object sender, RoutedEventArgs e)
        {
            UserPages.Content = new KartotekaPrzestępstwo();
        }
    }
}
