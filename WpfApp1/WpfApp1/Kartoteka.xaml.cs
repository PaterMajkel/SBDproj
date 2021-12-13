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
    public partial class Kartoteka : Page 
    {
        /*public DatabaseService databaseService = new();
        public ICollection<Kartoteka> data;
        public ICollection<Kartoteka> data2;
        public bool IdOrder = false;
        public Wykroczenia pickedWykroczenia;
        public Przestepstwo pickedPrzestepstwo;
        public ICollection<Wykroczenia> wykroczenia;
        public ICollection<Przestepstwo> przestepstwo;
        public string nazwisko;
        public string imie;
        public bool editMode = false;
        public int position;
        public List<Kartoteka_Przestepstwo> selectedToEdit;*/


        public Kartoteka()
        {
            InitializeComponent();
           // data = databaseService.();

        }
    }
}
