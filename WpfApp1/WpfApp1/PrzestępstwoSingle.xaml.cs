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
        public bool IdOrder = false;
        public PrzestępstwoSingle(Przestepstwo przes)
        {
            przestepstwo = databaseService.getPrzestepstwoByObj(przes);
            InitializeComponent();
            kartoteka = databaseService.GetKartotekas();
            policjant = databaseService.GetPolicjantsAndRank();
            Nazwa.Content = przestepstwo.Nazwa;
            Data.Content = przestepstwo.Data;
            Godzina.Content = przestepstwo.Godzina;

            ListViewColumnsPolicjanci.ItemsSource = przestepstwo.Policjants;
            ListViewColumnsSprawcy.ItemsSource = przestepstwo.Kartotekas;
            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));
            KartotekaBox.ItemsSource = kartoteka;
            PolicjantBox.ItemsSource = policjant;
        }
        private void ListView_OnColumnClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource.GetType().Name != "GridViewColumnHeader")
                return;
            string headerName = (e.OriginalSource as GridViewColumnHeader).Content.ToString();
            switch (headerName)
            {
                case "ID":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Kartotekas = przestepstwo.Kartotekas.OrderByDescending(id => id.KartotekaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        przestepstwo.Kartotekas = przestepstwo.Kartotekas.OrderBy(id => id.KartotekaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Imie":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Kartotekas = przestepstwo.Kartotekas.OrderByDescending(id => id.Imie).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        przestepstwo.Kartotekas = przestepstwo.Kartotekas.OrderBy(id => id.Imie).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwisko":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Kartotekas = przestepstwo.Kartotekas.OrderByDescending(id => id.Nazwisko).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        przestepstwo.Kartotekas = przestepstwo.Kartotekas.OrderBy(id => id.Nazwisko).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Wiek":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Kartotekas = przestepstwo.Kartotekas.OrderByDescending(id => id.Wiek).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        kartoteka = kartoteka.OrderBy(id => id.Wiek).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "ID.":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Policjants = przestepstwo.Policjants.OrderByDescending(id => id.PolicjantId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        przestepstwo.Policjants = przestepstwo.Policjants.OrderBy(id => id.PolicjantId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Imie.":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Policjants = przestepstwo.Policjants.OrderByDescending(id => id.Imie).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        przestepstwo.Policjants = przestepstwo.Policjants.OrderBy(id => id.Imie).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwisko.":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Policjants = przestepstwo.Policjants.OrderByDescending(id => id.Nazwisko).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        przestepstwo.Policjants = przestepstwo.Policjants.OrderBy(id => id.Nazwisko).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "KomendaId.":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Policjants = przestepstwo.Policjants.OrderByDescending(id => id.KomendaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        przestepstwo.Policjants = przestepstwo.Policjants.OrderBy(id => id.KomendaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Ranga.":
                    {
                        if (!IdOrder)
                        {
                            przestepstwo.Policjants = przestepstwo.Policjants.OrderByDescending(id => id.RangaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        przestepstwo.Policjants = przestepstwo.Policjants.OrderBy(id => id.RangaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumnsSprawcy.ItemsSource = przestepstwo.Kartotekas;
            ListViewColumnsPolicjanci.ItemsSource = przestepstwo.Policjants;

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
            policjant = databaseService.GetPolicjantsAndRank();

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
            Refresh();

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
            Refresh();

        }
    }

}

