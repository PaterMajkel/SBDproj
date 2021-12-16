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
    /// Logika interakcji dla klasy Radiowozy.xaml
    /// </summary>
    public partial class RadiowozyPage : Page
    {
        public DatabaseService databaseService = new();
        public ICollection<Radiowoz> data;
        public ICollection<Radiowoz> data2;
        public bool IdOrder = false;
        public string model;
        public string marka;
        public int? rocznik;
        public int? ilosc;
        private bool editMode = false;
        private Radiowoz selectedToEdit;
        public RadiowozyPage()
        {
            InitializeComponent();
            data = databaseService.GetRadiowozs();
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
                            data = data.OrderByDescending(id => id.RadiowozId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.RadiowozId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Model":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Model).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Model).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Marka":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Marka).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Marka).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Rok produkcji":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Rok_produkcji).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Rok_produkcji).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumns.ItemsSource = data;
        }
        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {
            if (!editMode)
            {
                if (marka == null || model == null || rocznik == 0 || ilosc == 0)
                {
                    MessageBox.Show("Wprowadzono złe dane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (rocznik <= 2005 || rocznik >= 2021)
                {
                    MessageBox.Show("Samochod nie moze byc starszy niz z 2005 roku lub pochodzić z przyszłości ", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (ilosc <= 0)
                {
                    MessageBox.Show("Zła ilość", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                for (int i = 0; i < ilosc; i++)
                    databaseService.AddRadiowozos(new Radiowoz { Model = model, Marka = marka, Rok_produkcji = (int)rocznik });
                RefreshData();
                return;
            }
            selectedToEdit.Model = Model.Text;
            selectedToEdit.Marka = Marka.Text;
            selectedToEdit.Rok_produkcji= int.Parse(Rocznik.Text);

            databaseService.EditRadiowoz(selectedToEdit);
            AbortChange();
            RefreshData();

        }
        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {
            model = Model.Text.ToString();
        }
        private void Marka_TextChanged(object sender, TextChangedEventArgs e)
        {
            marka = Marka.Text.ToString();
        }
        private void Rocznik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string pom = Rocznik.Text.ToString();
            rocznik = int.Parse(pom);
        }
        private void Ilosc_TextChanged(object sender, TextChangedEventArgs e)
        {
            string pom = Ilosc.Text.ToString();
            ilosc = int.Parse(pom);
        }
        private void Button_Click_Usun(object sender, RoutedEventArgs e)
        {
            var selected = ListViewColumns.SelectedItems.Cast<Radiowoz>().ToList();
            if (selected == null)
            {
                MessageBox.Show("Błąd przy usuwaniu!", "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            databaseService.DeleteRadiowozos(selected);
            foreach (var element in selected)
                data.Remove(element);
            ListViewColumns.ItemsSource = null;
            ListViewColumns.ItemsSource = data;
        }
        private void Button_Click_Filter(object sender, RoutedEventArgs e)
        {
            ListViewColumns.ItemsSource = data
               .Where(p => p.RadiowozId.ToString().Contains(FilterId.Text))
               .Where(p => p.Marka.ToUpper().Contains(FilterMarka.Text.ToUpper()))
               .Where(p => p.Model.ToUpper().Contains(FilterModel.Text.ToUpper()))
               .Where(p => p.Rok_produkcji.ToString().Contains(FilterRok.Text.ToUpper()))
               .ToList();
        }
        private void RefreshData()
        {
            data = databaseService.GetRadiowozs();
            ListViewColumns.ItemsSource = data;
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
            
            Model.Text = "";
            Marka.Text = "";
            Rocznik.Text = "";
            Ilosc.Text = "";
            Ilosc.IsEnabled = true;

        }

        private void Button_Click_Edytuj(object sender, RoutedEventArgs e)
        {
            selectedToEdit = (Radiowoz)ListViewColumns.SelectedItem;
            if (selectedToEdit == null)
            {
                MessageBox.Show("Błąd przy edytowaniu!", "Edytuj", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            editMode = true;
            AddEdit.Content = "Zmień";
            EditButton.IsEnabled = false;
            Abort.Visibility = Visibility.Visible;
            Marka.Text = selectedToEdit.Marka;
            Model.Text = selectedToEdit.Model;
            Rocznik.Text = selectedToEdit.Rok_produkcji.ToString();
            Ilosc.IsEnabled = false;
            CurrentMode.Content = $"Edytuj pozycję";
        }
    }
}
