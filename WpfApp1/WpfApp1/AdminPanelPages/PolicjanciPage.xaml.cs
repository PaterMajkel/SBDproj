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
        private bool isAdmin = false;
        public Uzytkownik selectedToEdit;

        public PolicjanciPage()
        {
            data = databaseService.GetUzytkowniks();
            InitializeComponent();
            ListViewColumns.ItemsSource = data;
            ranga = databaseService.GetRangas();
            komenda = databaseService.GetKomendas();
            KomendaBox.ItemsSource = komenda;
            RangaBox.ItemsSource = ranga;
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
            selectedToEdit = (Uzytkownik)ListViewColumns.SelectedItem;
            if (selectedToEdit == null)
            {
                MessageBox.Show("Błąd przy edytowaniu!", "Edytuj", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            editMode = true;
            AddEdit.Content = "Zmień";
            EditButton.IsEnabled = false;
            Abort.Visibility = Visibility.Visible;
            Name.Text = selectedToEdit.Policjant.Imie;
            Sunrame.Text = selectedToEdit.Policjant.Nazwisko;
            Login.Text = selectedToEdit.Login;
            Password.Text = selectedToEdit.Password;
            CurrentMode.Content = $"Edytuj pozycję";
            RangaBox.SelectedItem = selectedToEdit.Policjant.Ranga;
            KomendaBox.SelectedItem = selectedToEdit.Policjant.Komenda;
        }
        private void RefreshData()
        {
            data = databaseService.GetUzytkowniks();
            ListViewColumns.ItemsSource = data;
            ranga = databaseService.GetRangas();
            komenda = databaseService.GetKomendas();
            KomendaBox.ItemsSource = komenda;
            RangaBox.ItemsSource = ranga;
            isAdmin = false;
            AdminCheckBox.IsChecked = false;
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
            isAdmin = false;

            AdminCheckBox.IsChecked = false;
            Login.Text = "";
            Password.Text = "";
            Name.Text = "";
            Sunrame.Text = "";
            RangaBox.ItemsSource = ranga;
            KomendaBox.ItemsSource = komenda;

        }

        private void Button_Click_DodajOrEdytuj(object sender, RoutedEventArgs e)
        {
            if (!editMode)
            {
                Policjant policjant = new();
                if (!isAdmin && (((Komenda)KomendaBox.SelectedItem) == null || ((Ranga)RangaBox.SelectedItem) == null))
                {
                    MessageBox.Show("Wprowadzono złe dane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (!isAdmin && (Login.Text.Length == 0 || Password.Text.Length==0 || Name.Text.Length==0 || Sunrame.Text.Length == 0))
                {
                    MessageBox.Show("Wartości nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (isAdmin && (Login.Text.Length == 0 || Password.Text.Length == 0))
                {
                    MessageBox.Show("Wartości nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
 
                policjant = new Policjant { Imie = Name.Text, Nazwisko = Sunrame.Text, KomendaId = ((Komenda)KomendaBox.SelectedItem).KomendaId, RangaId = ((Ranga)RangaBox.SelectedItem).RangaId};

                databaseService.AddUzytkownik(new Uzytkownik { Login = Login.Text, Password = Password.Text, Rola = isAdmin ? "Admin" : "" }, policjant);
                RefreshData();
                return;
            }
            if(isAdmin!=true)
            {
                selectedToEdit.Policjant.RangaId = ((Ranga)RangaBox.SelectedItem).RangaId;
                selectedToEdit.Policjant.KomendaId = ((Komenda)KomendaBox.SelectedItem).KomendaId;
                selectedToEdit.Policjant.Imie = Name.Text;
                selectedToEdit.Policjant.Nazwisko = Sunrame.Text;
            }
            selectedToEdit.Login = Login.Text;
            selectedToEdit.Password = Password.Text;


            databaseService.EditUzytkownik(selectedToEdit);
            AbortChange();
            RefreshData();

        }

        private void Button_Click_Filter(object sender, RoutedEventArgs e)
        {
            ListViewColumns.ItemsSource = data
               .Where(p => p.UzytkownikId.ToString().Contains(FilterId.Text))
               .Where(p => p.Policjant.Imie.ToUpper().Contains(FilterImie.Text.ToUpper()))
               .Where(p => p.Policjant.Nazwisko.ToUpper().Contains(FilterNazwisko.Text.ToUpper()))
               .Where(p => p.Policjant.Ranga.Nazwa.ToUpper().Contains(FilterRanga.Text.ToUpper()))
               .Where(p => p.Policjant.Komenda.KomendaId.ToString().Contains(FilterIdKomendy.Text.ToUpper()))
               .Where(p => p.Policjant.Komenda.Adres.ToUpper().Contains(FilterAdres.Text.ToUpper()))
               .ToList();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isAdmin = !isAdmin;

        }
    }
}
