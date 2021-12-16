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
    /// Logika interakcji dla klasy RegionPanel.xaml
    /// </summary>
    public partial class RegionPanel : Page
    {
        public bool IdOrder = false;
        public ICollection<Region_Miasta> data;
        private DatabaseService databaseService = new();
        private string[] levels = { "Niski", "Średni", "Wysoki", "Śmiertelny" };
        private bool editMode = false;
        private Region_Miasta selectedToEdit;
        public RegionPanel()
        {
            data = databaseService.getRegions();
            InitializeComponent();
            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));
            ListViewColumns.ItemsSource = data;
            EditBox.ItemsSource = levels;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            selectedToEdit.Stopien_zagrozenia = EditBox.SelectedItem.ToString() ;
            databaseService.editRegion(selectedToEdit);
            RefreshData();
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
                            data = data.OrderByDescending(id => id.Region_MiastaId).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Region_MiastaId).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Miasto":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Miasto.Nazwa).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Miasto.Nazwa).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Nazwa":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Nazwa).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Nazwa).ToList();
                        IdOrder = !IdOrder;
                        break;
                    }
                case "Stopień zagrożenia":
                    {
                        if (!IdOrder)
                        {
                            data = data.OrderByDescending(id => id.Stopien_zagrozenia).ToList();
                            IdOrder = !IdOrder;
                            break;
                        }
                        data = data.OrderBy(id => id.Stopien_zagrozenia).ToList();
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
            data = databaseService.getRegions();
            ListViewColumns.ItemsSource = data;
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            editMode = true;
            EditBox.SelectedItem = ((Region_Miasta)ListViewColumns.SelectedItem).Stopien_zagrozenia;
            selectedToEdit = (Region_Miasta)ListViewColumns.SelectedItem;

        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }
    }
}
