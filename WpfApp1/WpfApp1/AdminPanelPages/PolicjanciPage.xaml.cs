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
        public ICollection<Policjant> data;
        public ICollection<Policjant> data2;

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
            InitializeComponent();
           // AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));
        }
    }
}
