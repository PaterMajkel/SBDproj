using EntityFramework;
using EntityFramework.Models;
using Microsoft.Extensions.DependencyInjection;
using PoliceApp;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SharedData data;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public MainWindow(Uzytkownik uzytkownik)
        {
            if (uzytkownik.Rola == "Admin")
                AdminPanel.IsEnabled=true;
            UserPanel.IsEnabled = true;
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            Window loginPanel = new LoginPanel(ref UserPanel, ref AdminPanel, data);
            loginPanel.Show();

        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            Window adminPanel = new AdminPanel();
            adminPanel.Show();
        }

        private void UserPanel_Click(object sender, RoutedEventArgs e)
        {
            Window paneluzytkownika = new PanelUzytkownika();
            paneluzytkownika.Show();

        }
    }
}
