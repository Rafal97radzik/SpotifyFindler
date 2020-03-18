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

namespace SpotifyFindler
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private APIClient client;
        private SearchViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new SearchViewModel();
            MainFrame.Navigate(new MainPage(viewModel));
            client = new APIClient(viewModel);
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            _=client.SearchAsync(searchBox.Text, 20, 0, SearchType.album, SearchType.track, SearchType.playlist, SearchType.artist);
        }
    }
}
