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

namespace PoliceApp
{
    /// <summary>
    /// Logika interakcji dla klasy KartotekaOsoba.xaml
    /// </summary>
    public partial class KartotekaOsoba : Window
    {
        public Kartoteka kartoteka;
        public KartotekaOsoba(Kartoteka osoba)
        {
            kartoteka = osoba;
            //Console.WriteLine(kartoteka.Nazwisko);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         //   Close();
            MessageBox.Show(kartoteka.Nazwisko, "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
