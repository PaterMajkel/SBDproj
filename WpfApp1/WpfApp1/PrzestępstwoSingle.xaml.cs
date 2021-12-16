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
    /// Logika interakcji dla klasy PrzestępstwoSingle.xaml
    /// </summary>
    public partial class PrzestępstwoSingle : Window
    {
        private DatabaseService databaseService = new();
        public Przestepstwo przestepstwo;
        public Kartoteka pickedKartoteka;
        public Policjant pickedPolicjant;
        public ICollection<Kartoteka> kartoteka;
        public ICollection<Policjant> policjant;
        public PrzestępstwoSingle(Przestepstwo przes)
        {
            przestepstwo = databaseService.getPrzestepstwoByObj(przes);
            InitializeComponent();
            kartoteka = databaseService.GetKartotekas();
            policjant = databaseService.GetPolicjants();
            Nazwa.Content = przestepstwo.Nazwa;
            Data.Content = przestepstwo.Data;
            Godzina.Content = przestepstwo.Godzina;

            ListViewColumnsPolicjanci.ItemsSource = przestepstwo.Policjants;
            ListViewColumnsSprawcy.ItemsSource = przestepstwo.Kartotekas;

            KartotekaBox.ItemsSource = kartoteka;
            PolicjantBox.ItemsSource = policjant;
        }

        private void AddSprawca_Click(object sender, RoutedEventArgs e)
        {
            pickedKartoteka = (Kartoteka)KartotekaBox.SelectedItem;
            if (pickedKartoteka != null)
            {
                if (przestepstwo.Kartotekas.Contains(pickedKartoteka))
                {
                    MessageBox.Show("Dana osoba nie może uczystniczyć w jednym wydarzeniu kilkukrotnie", "Co Ty wyprawiasz?", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                databaseService.AddKartotekaToPrzestepstwo(przestepstwo, pickedKartoteka);
            }
            Refresh();
        }
        private void Refresh()
        {
            przestepstwo = databaseService.getPrzestepstwoByObj(przestepstwo);
            kartoteka = databaseService.GetKartotekas();
            policjant = databaseService.GetPolicjants();

            ListViewColumnsPolicjanci.ItemsSource = null;
            ListViewColumnsSprawcy.ItemsSource = null;

            ListViewColumnsPolicjanci.ItemsSource = przestepstwo.Policjants;
            ListViewColumnsSprawcy.ItemsSource = przestepstwo.Kartotekas;

            KartotekaBox.ItemsSource = kartoteka;
            PolicjantBox.ItemsSource = policjant;
        }

        private void Add_Policjant_Click(object sender, RoutedEventArgs e)
        {
            pickedPolicjant = (Policjant)PolicjantBox.SelectedItem;
            if (pickedPolicjant != null)
            {
                if (przestepstwo.Policjants.Contains(pickedPolicjant))
                {
                    MessageBox.Show("Dana osoba nie może uczystniczyć w jednym wydarzeniu kilkukrotnie", "Co Ty wyprawiasz?", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                databaseService.AddPolicjatToPrzestepstwo(przestepstwo, pickedPolicjant);
            }
            Refresh();
        }
        private void Delete_Policjant_Click(object sender, RoutedEventArgs e)
        {
            var pickedPolicjants = ListViewColumnsPolicjanci.SelectedItems.Cast<Policjant>().ToList();
            if (pickedPolicjants == null)
            {
                MessageBox.Show("Błąd przy usuwaniu!", "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            databaseService.DeletePolicjantsFromPrzestepstwo(przestepstwo, pickedPolicjants);
            //usuwanie lokalne, aby nie pobierać od nowa informacji

        }
        private void Delete_Sprawca_Click(object sender, RoutedEventArgs e)
        {
            var pickedSprawcy = ListViewColumnsSprawcy.SelectedItems.Cast<Kartoteka>().ToList();
            if (pickedSprawcy == null)
            {
                MessageBox.Show("Błąd przy usuwaniu!", "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            databaseService.DeleteSprawcaFromPrzestepstwo(przestepstwo, pickedSprawcy);
            //usuwanie lokalne, aby nie pobierać od nowa informacji

        }
    }

}

