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
        private void Refresh()
        {
            wykroczenia = databaseService.getWykroczenieByObj(wykroczenia);
            kartoteka = databaseService.GetKartotekas();
            policjant = databaseService.GetPolicjants();

            ListViewColumnsPolicjanci.ItemsSource = null;
            ListViewColumnsSprawcy.ItemsSource = null;

            ListViewColumnsPolicjanci.ItemsSource = wykroczenia.Policjants;
            ListViewColumnsSprawcy.ItemsSource = wykroczenia.Kartotekas;

            KartotekaBox.ItemsSource = kartoteka;
            PolicjantBox.ItemsSource = policjant;
        }

        private void Add_Policjant_Click(object sender, RoutedEventArgs e)
        {
            pickedPolicjant = (Policjant)PolicjantBox.SelectedItem;
            if (pickedPolicjant != null)
            {
                if (wykroczenia.Policjants.Contains(pickedPolicjant))
                {
                    MessageBox.Show("Dana osoba nie może uczystniczyć w jednym wydarzeniu kilkukrotnie", "Co Ty wyprawiasz?", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                databaseService.AddPolicjantToWykroczenie(wykroczenia, pickedPolicjant);
            }
            Refresh();
        }

        private void AddSprawca_Click(object sender, RoutedEventArgs e)
        {
            pickedKartoteka = (Kartoteka)KartotekaBox.SelectedItem;
            if (pickedKartoteka != null)
            {
                if (wykroczenia.Kartotekas.Contains(pickedKartoteka))
                {
                    MessageBox.Show("Dana osoba nie może uczystniczyć w jednym wydarzeniu kilkukrotnie", "Co Ty wyprawiasz?", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                databaseService.AddKartotekaToWykroczenie(wykroczenia, pickedKartoteka);
            }
            Refresh();
        }
    }
}
