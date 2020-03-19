using SpotifyFindler.API;
using SpotifyFindler.Pages;
using SpotifyFindler.ViewModels;
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
using SpotifyAPI.Enums;
using SpotifyFindler.Controllers;

namespace SpotifyFindler
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SearchPage searchPage;

        public static Frame MainWindowFrame { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowFrame = MainFrame;
            searchPage = new SearchPage();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Navigate(searchPage);
            searchPage.Search(searchTextBox.Text);
        }
    }
}
