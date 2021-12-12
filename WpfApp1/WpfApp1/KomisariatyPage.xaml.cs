using EntityFramework.DTO;
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
        public ICollection<Komenda_Miasto_Region> data;
        public bool IdOrder = false;
        public KomisariatyPage()
        {
            InitializeComponent();
            data = databaseService.GetKomendas();
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
                            data = (ICollection<Komenda_Miasto_Region>)data.OrderByDescending(id => id.ID_komendy).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = (ICollection<Komenda_Miasto_Region>)data.OrderBy(id => id.ID_komendy).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Adres":
                    {
                        if (!IdOrder)
                        {
                            data = (ICollection<Komenda_Miasto_Region>)data.OrderByDescending(id => id.Adres).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = (ICollection<Komenda_Miasto_Region>)data.OrderBy(id => id.Adres).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Region":
                    {
                        if (!IdOrder)
                        {
                            data = (ICollection<Komenda_Miasto_Region>)data.OrderByDescending(id => id.Nazwa_regionu).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = (ICollection<Komenda_Miasto_Region>)data.OrderBy(id => id.Nazwa_regionu).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Miasto":
                    {
                        if (!IdOrder)
                        {
                            data = (ICollection<Komenda_Miasto_Region>)data.OrderByDescending(id => id.Nazwa_miasta).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = (ICollection<Komenda_Miasto_Region>)data.OrderBy(id => id.Nazwa_miasta).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Stopien Zagrozenia":
                    {
                        if (!IdOrder)
                        {
                            data = (ICollection<Komenda_Miasto_Region>)data.OrderByDescending(id => id.Stopien_zagrozenia).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = (ICollection<Komenda_Miasto_Region>)data.OrderBy(id => id.Stopien_zagrozenia).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumns.ItemsSource = data;

        }

        private void Button_Click_Usun(object sender, RoutedEventArgs e)
        {
            var selected = ListViewColumns.SelectedItems.Cast<Komenda_Miasto_Region>().ToList();
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
    }
}
