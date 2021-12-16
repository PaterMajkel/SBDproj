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
        public bool IdOrder = false;
        public Wykroczenia wykroczeniepom;
        public WykroczenieSingle(Wykroczenia wykro)
        {
            wykroczenia = databaseService.getWykroczenieByObj(wykro);
            kartoteka = databaseService.GetKartotekas();
            policjant = databaseService.GetPolicjantsAndRank();
            InitializeComponent();
            Nazwa.Content = wykroczenia.Nazwa;
            Data.Content = wykroczenia.Data;
            Godzina.Content = wykroczenia.Godzina;


            ListViewColumnsPolicjanci.ItemsSource = wykroczenia.Policjants;
            ListViewColumnsSprawcy.ItemsSource = wykroczenia.Kartotekas;
            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));
            KartotekaBox.ItemsSource = kartoteka;
            PolicjantBox.ItemsSource= policjant;
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
                            wykroczenia.Kartotekas = wykroczenia.Kartotekas.OrderByDescending(id => id.KartotekaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        wykroczenia.Kartotekas = wykroczenia.Kartotekas.OrderBy(id => id.KartotekaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Imie":
                    {
                        if (!IdOrder)
                        {
                            wykroczenia.Kartotekas = wykroczenia.Kartotekas.OrderByDescending(id => id.Imie).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        wykroczenia.Kartotekas = wykroczenia.Kartotekas.OrderBy(id => id.Imie).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwisko":
                    {
                        if (!IdOrder)
                        {
                            wykroczenia.Kartotekas = wykroczenia.Kartotekas.OrderByDescending(id => id.Nazwisko).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        wykroczenia.Kartotekas = wykroczenia.Kartotekas.OrderBy(id => id.Nazwisko).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Wiek":
                    {
                        if (!IdOrder)
                        {
                            wykroczenia.Kartotekas = wykroczenia.Kartotekas.OrderByDescending(id => id.Wiek).ToList();
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
                            wykroczenia.Policjants = wykroczenia.Policjants.OrderByDescending(id => id.PolicjantId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        wykroczenia.Policjants = wykroczenia.Policjants.OrderBy(id => id.PolicjantId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Imie.":
                    {
                        if (!IdOrder)
                        {
                            wykroczenia.Policjants = wykroczenia.Policjants.OrderByDescending(id => id.Imie).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        wykroczenia.Policjants = wykroczenia.Policjants.OrderBy(id => id.Imie).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwisko.":
                    {
                        if (!IdOrder)
                        {
                            wykroczenia.Policjants = wykroczenia.Policjants.OrderByDescending(id => id.Nazwisko).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        wykroczenia.Policjants = wykroczenia.Policjants.OrderBy(id => id.Nazwisko).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "KomendaID.":
                    {
                        if (!IdOrder)
                        {
                            wykroczenia.Policjants = wykroczenia.Policjants.OrderByDescending(id => id.KomendaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        wykroczenia.Policjants = wykroczenia.Policjants.OrderBy(id => id.KomendaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Ranga.":
                    {
                        if (!IdOrder)
                        {
                            wykroczenia.Policjants = wykroczenia.Policjants.OrderByDescending(id => id.RangaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        wykroczenia.Policjants = wykroczenia.Policjants.OrderBy(id => id.RangaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumnsSprawcy.ItemsSource = wykroczenia.Kartotekas;
            ListViewColumnsPolicjanci.ItemsSource = wykroczenia.Policjants;

        }
        private void Refresh()
        {
            wykroczenia = databaseService.getWykroczenieByObj(wykroczenia);
            kartoteka = databaseService.GetKartotekas();
            policjant = databaseService.GetPolicjantsAndRank();

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
        private void Delete_Policjant_Click(object sender, RoutedEventArgs e)
        {
            var pickedPolicjants = ListViewColumnsPolicjanci.SelectedItems.Cast<Policjant>().ToList();
            if (pickedPolicjants == null)
            {
                MessageBox.Show("Błąd przy usuwaniu!", "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            databaseService.DeletePolicjantsFromWykroczenie(wykroczenia, pickedPolicjants);
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
            databaseService.DeleteSprawcaFromWykroczenia(wykroczenia, pickedSprawcy);
            //usuwanie lokalne, aby nie pobierać od nowa informacji

        }
    }
}

