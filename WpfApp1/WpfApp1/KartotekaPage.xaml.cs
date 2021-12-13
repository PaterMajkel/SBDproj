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
    /// Logika interakcji dla klasy Kartoteka.xaml
    /// </summary>
    public partial class KartotekaPage : Page 
    {
        public DatabaseService databaseService = new();
        public ICollection<Kartoteka> data;
        public ICollection<Kartoteka> data2;
        public bool IdOrder = false;
        public List<Kartoteka_Przestepstwo> selectedToEdit;


        public KartotekaPage()
        {
            InitializeComponent();
            data = databaseService.GetKartotekas();
            ;

        }
        private void ListView_OnColumnClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource.GetType().Name != "GridViewColumnHeader")
                return;
            string headerName=(e.OriginalSource as GridViewColumnHeader).Content.ToString();
            switch(headerName)
            {
                case "ID":
                    {
                        if(!IdOrder)
                        {
                            //data = data.OrderByDescending(id => id.KartotekaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                       // data = data.OrderBy(id => id.KartotekaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Imię":
                    {
                        if (!IdOrder)
                        {
                           // data = data.OrderByDescending(id => id.Imie).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        //data = data.OrderBy(id => id.Imie).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwisko":
                    {
                        if (!IdOrder)
                        {
                            //data = data.OrderByDescending(id => id.Nazwisko).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        //data = data.OrderBy(id => id.Nazwisko).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Wiek":
                    {
                        if (!IdOrder)
                        {
                            //data = data.OrderByDescending(id => id.Wiek).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        //data = data.OrderBy(id => id.Wiek).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumns.ItemsSource = data;
        }

        private void ListViewColumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void RefreshData()
        {
            //data2 = databaseService.GetKartotekas();
            ListViewColumns.ItemsSource = data;
        }
    }
}
