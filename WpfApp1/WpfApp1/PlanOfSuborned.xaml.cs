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
    /// Logika interakcji dla klasy PlanOfSuborned.xaml
    /// </summary>
    public partial class PlanOfSuborned : Window
    {
        public ICollection<Patrol> patrol;
        public Policjant policjant;
        private DatabaseService databaseService = new();

        public PlanOfSuborned(Patrol pato)
        {
           // policjant=databaseService.GetPolicjantByObj()
            InitializeComponent();
        }
    }
}
