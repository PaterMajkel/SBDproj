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
    /// Logika interakcji dla klasy Podwladni.xaml
    /// </summary>
    public partial class Podwladni : Page
    {
        private ICollection<Policjant> data;
        private ICollection<Radiowoz> radiowozy;
        private DatabaseService databaseService = new();
        private SharedData user = SharedData.GetInstance(null);
        private bool IdOrder = false;
        public Podwladni()
        {
            var policjant = databaseService.GetUzytkownikByObj(user.uzytkownik);
            data = databaseService.GetPodwladni(policjant.Policjant);
            radiowozy = databaseService.GetRadiowozs();
            InitializeComponent();
            ListViewColumns.ItemsSource = data;
            RadiowozBox.ItemsSource = radiowozy;
            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));

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
                            data = data.OrderByDescending(id => id.PolicjantId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.PolicjantId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Imie":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Imie).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Imie).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwisko":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Nazwisko).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Nazwisko).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Wiek":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Ranga.Nazwa).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Ranga.Nazwa).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Komenda adres":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Komenda.Adres).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Komenda.Adres).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumns.ItemsSource = data;
        }
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as Patrol;
            if (item != null)
            {
                Window patrolsingle = new PlanOfSuborned(item);
                patrolsingle.Show();
            }
        }


    }
}
