using EntityFramework.DTO;
using EntityFramework.Models;
using EntityFramework.Services;
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

namespace PoliceApp
{
    /// <summary>
    /// Logika interakcji dla klasy WykroczenieSingle.xaml
    /// </summary>
    public partial class WykroczenieSingle : Window
    {
        public Wykroczenia wykroczenia;
        private DatabaseService databaseService = new();
        public Kartoteka pickedKartoteka;
        public Policjant pickedPolicjant;
        public ICollection<Kartoteka> kartoteka;
        public ICollection<Policjant> policjant;
        public Wykroczenia wykroczeniepom;
        public WykroczenieSingle(Wykroczenia wykro)
        {
            wykroczenia = databaseService.getWykroczenieByObj(wykro);
            kartoteka = databaseService.GetKartotekas();
            policjant = databaseService.GetPolicjants();
            InitializeComponent();
            Nazwa.Content = wykroczenia.Nazwa;
            Data.Content = wykroczenia.Data;
            Godzina.Content = wykroczenia.Godzina;


            ListViewColumnsPolicjanci.ItemsSource = wykroczenia.Policjants;
            ListViewColumnsSprawcy.ItemsSource = wykroczenia.Kartotekas;

            KartotekaBox.ItemsSource = kartoteka;
            PolicjantBox.ItemsSource= policjant;
        }
        private void Button_Click_DodajSprawce(object sender, RoutedEventArgs e)
        {
            if(pickedKartoteka==null)
            {
                MessageBox.Show("Nie Wybrano Sprawcy", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            wykroczeniepom.WykroczenieId = wykroczenia.WykroczenieId;
            wykroczeniepom.Nazwa = wykroczenia.Nazwa;
            wykroczeniepom.Data = wykroczenia.Data;
            wykroczeniepom.Godzina = wykroczenia.Godzina;


        }
        private void ComboBoxPolicjant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pickedPolicjant = (Policjant)PolicjantBox.SelectedItem;
        }
        private void ComboBoxKartoteka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pickedKartoteka = (Kartoteka)KartotekaBox.SelectedItem;
        }

    }
}
