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
    /// Logika interakcji dla klasy KomisariatyPage.xaml
    /// </summary>
    public partial class KomisariatyPage : Page
    {
        public DatabaseService databaseService = new();
        public ICollection<Komenda> data;
        public bool IdOrder = false;
        public Miasto pickedMiasto;
        public Region_Miasta pickedRegion;
        public ICollection<Miasto> miasta;
        public ICollection<Region_Miasta> regiony;
        public string adres;
        public bool editMode = false;
        public Komenda selectedToEdit;
        public KomisariatyPage()
        {
            InitializeComponent();
            data = databaseService.GetKomendas();
            miasta = databaseService.GetMiastos();
             AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));
            //foreach (var x in data)
            //{
            //    ListViewColumns.Items.Add(x);
            //}
            // skalowanie z ilością danych
            //List<Komenda_Miasto_Region> data2=data.ToList();
            //List<Komenda_Miasto_Region> data3 = data.ToList();
            //
            //for (int i=0; i<20; i++)
            //{
            //    data2.Add(data3[i%9]);
            //}
            ListViewColumns.ItemsSource = data;
            MiastoBox.ItemsSource = miasta;
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
                            data = data.OrderByDescending(id => id.KomendaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.KomendaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Adres":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Adres).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Adres).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Region":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Region_Miasta.Nazwa).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Region_Miasta.Nazwa).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Miasto":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Region_Miasta.Miasto.Nazwa).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Region_Miasta.Miasto.Nazwa).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Stopien Zagrozenia":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Region_Miasta.Stopien_zagrozenia).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Region_Miasta.Stopien_zagrozenia).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumns.ItemsSource = data;

        }

        private void Button_Click_Usun(object sender, RoutedEventArgs e)
        {
            var selected = ListViewColumns.SelectedItems.Cast<Komenda>().ToList();
            if (selected == null)
            {
                MessageBox.Show("Błąd przy usuwaniu!", "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            databaseService.DeleteKomendas(selected);
            //usuwanie lokalne, aby nie pobierać od nowa informacji
            foreach(var element in selected)
            {
                data.Remove(element);
            }
            ListViewColumns.ItemsSource = null;
            ListViewColumns.ItemsSource = data;
        }
        private void Button_Click_Edytuj(object sender, RoutedEventArgs e)
        {
            selectedToEdit = (Komenda)ListViewColumns.SelectedItem;
            if (selectedToEdit == null)
            {
                MessageBox.Show("Błąd przy edytowaniu!", "Edytuj", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            editMode = true;
            AddEdit.Content = "Zmień";
            EditButton.IsEnabled = false;
            Abort.Visibility = Visibility.Visible;
            Adres.Text = selectedToEdit.Adres;

            CurrentMode.Content = $"Edytuj pozycję";
            MiastoBox.SelectedItem = selectedToEdit.Region_Miasta.Miasto;
            RegionBox.SelectedItem = selectedToEdit.Region_Miasta;

        }

        private void ComboBoxMiasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pickedMiasto= (Miasto)MiastoBox.SelectedItem;
            regiony = databaseService.getRegionsOfMiasto(pickedMiasto);
            RegionBox.ItemsSource = regiony;
        }

        private void ComboBoxRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pickedRegion = (Region_Miasta)RegionBox.SelectedItem;

        }

        private void Button_Click_DodajOrEdytuj(object sender, RoutedEventArgs e)
        {
            if (!editMode)
            {
                if (pickedMiasto == null || pickedRegion == null || adres==null)
                {
                    MessageBox.Show("Wprowadzono złe dane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (adres.Length == 0)
                {
                    MessageBox.Show("Adres nie może być pusty", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                databaseService.AddKomenda(new Komenda {Adres = adres, Region_MiastaId = pickedRegion.Region_MiastaId, Region_Miasta = pickedRegion });
                RefreshData();
                return;
            }
            selectedToEdit.Adres = Adres.Text;
            selectedToEdit.Region_MiastaId = ((Region_Miasta)RegionBox.SelectedItem).Region_MiastaId;
            databaseService.EditKomenda(selectedToEdit);
            AbortChange();
            RefreshData();

        }
        private void Adres_TextChanged(object sender, TextChangedEventArgs e)
        {
            adres = Adres.Text.ToString();
        }
        private void RefreshData()
        {
            data = databaseService.GetKomendas();
            miasta = databaseService.GetMiastos();
            ListViewColumns.ItemsSource = data;
            MiastoBox.ItemsSource = miasta;
        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void Button_Click_Abort(object sender, RoutedEventArgs e)
        {
            AbortChange();
        }
        public void AbortChange()
        {
            editMode = false;
            AddEdit.Content = "Dodaj";
            Abort.Visibility = Visibility.Hidden;
            CurrentMode.Content = $"Nowa pozycja";
            EditButton.IsEnabled = true;

            Adres.Text = "";
            MiastoBox.ItemsSource = miasta;

        }

        private void Button_Click_Filter(object sender, RoutedEventArgs e)
        {
            ListViewColumns.ItemsSource = data
                .Where(p => p.KomendaId.ToString().Contains(FilterId.Text))
                .Where(p => p.Adres.ToUpper().Contains(FilterAdres.Text.ToUpper()))
                .Where(p => p.Region_Miasta.Nazwa.ToUpper().Contains(FilterRegion.Text.ToUpper()))
                .Where(p => p.Region_Miasta.Miasto.Nazwa.ToUpper().Contains(FilterMiasto.Text.ToUpper()))
                .Where(p => p.Region_Miasta.Stopien_zagrozenia.ToUpper().Contains(FilterStopien.Text.ToUpper()))
                .ToList();
        }
    }
}
