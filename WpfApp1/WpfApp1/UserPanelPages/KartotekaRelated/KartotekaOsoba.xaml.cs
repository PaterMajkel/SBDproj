using EntityFramework.Models;
using EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logika interakcji dla klasy KartotekaOsoba.xaml
    /// </summary>
    public partial class KartotekaOsoba : Window
    {
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public Kartoteka kartoteka;
        private DatabaseService databaseService = new();
        public KartotekaOsoba(Kartoteka osoba)
        {
            kartoteka = databaseService.getKartotekaByObj(osoba);
            //Console.WriteLine(kartoteka.Nazwisko);
            InitializeComponent();
            Imie.Content = kartoteka.Imie;
            Nazwisko.Content = kartoteka.Nazwisko;
            Wiek.Content = kartoteka.Wiek.ToString();
            ListViewColumnsPrzestepstwa.ItemsSource = kartoteka.Przestepstwos;
            ListViewColumnsWykroczenia.ItemsSource = kartoteka.Wykroczenias;
            Image.Source = LoadImage(kartoteka.Zdjecie);
        }

    }
}
