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
    /// Logika interakcji dla klasy KartotekaZdarzenie.xaml
    /// </summary>
    public partial class KartotekaWykroczenie : Page
    {
        public DatabaseService databaseService = new();
        public ICollection<Wykroczenia> data;
        public bool IdOrder = false;
        public string nazwa;
        public string dzien;
        public string godzina;
        public KartotekaWykroczenie()
        {
            InitializeComponent();
            data = databaseService.GetWykroczenias();
            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));
            ListViewColumns.ItemsSource = data;
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
                            data = data.OrderByDescending(id => id.WykroczenieId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.WykroczenieId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwa":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Nazwa).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Nazwa).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Data":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Data).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Data).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Godzina":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Godzina).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Godzina).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumns.ItemsSource = data;
        }
        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {
            if (nazwa == null || dzien == null || godzina == null)
            {
                MessageBox.Show("Wprowadzono złe dane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            databaseService.AddWykroczenias(new Wykroczenia { Nazwa = nazwa, Data = dzien, Godzina = godzina, });
        }
        private void Nazwa_TextChanged(object sender, TextChangedEventArgs e)
        {
            nazwa = Nazwa.Text.ToString();
        }
        private void Data_TextChanged(object sender, TextChangedEventArgs e)
        {
            dzien = Data.Text.ToString();
        }
        private void Godzina_TextChanged(object sender, TextChangedEventArgs e)
        {
            godzina = Godzina.Text.ToString();
        }
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as Wykroczenia;
            if (item != null)
            {
                Window wykroczeniesingle = new WykroczenieSingle(item);
                wykroczeniesingle.Show();
            }
        }
        private void Button_Click_Usun(object sender, RoutedEventArgs e)
        {
            var selected = ListViewColumns.SelectedItems.Cast<Wykroczenia>().ToList();
            if (selected == null)
            {
                MessageBox.Show("Błąd przy usuwaniu!", "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            databaseService.DeleteWykroczenias(selected);
            foreach (var element in selected)
                data.Remove(element);
            ListViewColumns.ItemsSource = null;
            ListViewColumns.ItemsSource = data;
        }
        private void ListViewColumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}



