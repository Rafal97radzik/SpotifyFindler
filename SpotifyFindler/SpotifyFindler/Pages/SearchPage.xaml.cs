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

namespace SpotifyFindler.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        private string queryKeywords;
        private SearchViewModel viewModel;

        public SearchPage()
        {
            InitializeComponent();

            viewModel = (DataContext as SearchViewModel);
        }

        public void Search(string queryKeywords)
        {
            this.queryKeywords = queryKeywords;
            viewModel.Search(queryKeywords);
        }

        private void albumsLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainWindowFrame.Navigate(new SearchAlbumPage(queryKeywords));
        }

        private void tracksLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void artistsLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void artistsLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void playlistsLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
