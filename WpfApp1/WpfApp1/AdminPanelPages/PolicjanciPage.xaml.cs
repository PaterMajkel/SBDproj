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
    /// Logika interakcji dla klasy Policjanci.xaml
    /// </summary>
    public partial class PolicjanciPage : Page
    {
        public DatabaseService databaseService = new();
        public ICollection<Uzytkownik> data;

        public bool IdOrder = false;

        public Ranga pickedRanga;
        public Komenda pickedKomenda;
        public ICollection<Ranga> ranga;
        public ICollection<Komenda> komenda;
        public string imie;
        public string nazwisko;
        public string login;
        public string password;
        public bool editMode = false;

        public PolicjanciPage()
        {
            data = databaseService.GetUzytkowniks();
            InitializeComponent();
            ListViewColumns.ItemsSource = data;
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
                            data = data.OrderByDescending(id => id.UzytkownikId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.UzytkownikId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Imie":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Policjant.Imie).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Policjant.Imie).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwisko":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Policjant.Nazwisko).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Policjant.Nazwisko).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Ranga":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Policjant.Ranga.Nazwa).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Policjant.Ranga.Nazwa).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Komenda":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Policjant.Komenda.KomendaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Policjant.Komenda.KomendaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
            }
            ListViewColumns.ItemsSource = data;

        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            var selected = ListViewColumns.SelectedItems.Cast<Uzytkownik>().ToList();
            if (selected == null)
            {
                MessageBox.Show("Błąd przy usuwaniu!", "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            databaseService.DeleteUzytkowniks(selected);
            //usuwanie lokalne, aby nie pobierać od nowa informacji
            foreach (var element in selected)
            {
                if(element.Rola.ToUpper()=="ADMIN")
                    MessageBox.Show("CZY TY SERIO PRÓBOWAŁEŚ USUNĄĆ ADMINA?!", "Usuń", MessageBoxButton.OK, MessageBoxImage.Error);

                data.Remove(element);
            }
            ListViewColumns.ItemsSource = null;
            ListViewColumns.ItemsSource = data;
        }
    
        private void Button_Click_Edytuj(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_Abort(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_AddOrEdit(object sender, RoutedEventArgs e)
        {

        }

    }
}
