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
using System.Windows.Shapes;

namespace PoliceApp
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPanel.xaml
    /// </summary>
    public partial class LoginPanel : Window
    {
        string login;
        List<Button> buttons;
        SharedData uzytkownik;
        public DatabaseService databaseService = new DatabaseService();
        public LoginPanel(ref Button userButt, ref Button adminButt, SharedData uzytkownik)
        {
            this.uzytkownik = uzytkownik;
            buttons = new List<Button>();
            buttons.Add(userButt);
            buttons.Add(adminButt);
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = loginBox.Text;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = databaseService.GetUzytkownik(login, passwordBox.Password.ToString());
            if (x != null)
            {
                uzytkownik=new SharedData { uzytkownik=x};
                buttons[0].IsEnabled = true;
                if (x.Rola.ToUpper() == "ADMIN")
                    buttons[1].IsEnabled = true;
                Close();
                return;
            }
            foreach (var button in buttons)
                button.IsEnabled = false;
            MessageBox.Show("Złe dane logowania","Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);

        }

    }
}
