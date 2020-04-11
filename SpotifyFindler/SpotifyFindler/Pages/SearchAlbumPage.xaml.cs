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
    /// Logika interakcji dla klasy SearchAlbumPage.xaml
    /// </summary>
    public partial class SearchAlbumPage : Page
    {
        private SearchAlbumViewModel viewModel;
        private DateTime lastUpdateTime;
        private string queryKeywords;

        public SearchAlbumPage(string queryKeywords)
        {
            InitializeComponent();
            viewModel = DataContext as SearchAlbumViewModel;

            this.queryKeywords = queryKeywords;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lastUpdateTime = DateTime.Now.AddMilliseconds(500);
            viewModel.Search(queryKeywords);
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if ((e.ExtentHeight-20)<=(e.VerticalOffset+e.ViewportHeight) && lastUpdateTime.AddMilliseconds(500) < DateTime.Now)
            {
                viewModel.GetNextAlbums();
                lastUpdateTime = DateTime.Now;
            } 
        }
    }
}
