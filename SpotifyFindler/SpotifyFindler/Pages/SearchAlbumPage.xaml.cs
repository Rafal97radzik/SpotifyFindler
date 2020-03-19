using SpotifyFindler.Controllers;
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
        private SearchAlbumController controller;
        private DateTime lastUpdateTime;

        public SearchAlbumPage(string queryKeywords)
        {
            InitializeComponent();
            var viewModel = DataContext as SearchAlbumViewModel;
            controller = new SearchAlbumController(viewModel, queryKeywords);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            controller.GetNextAlbums();
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var x = e.ExtentHeight - e.VerticalOffset;

            if (x < ActualHeight + 100 && lastUpdateTime.AddMilliseconds(100) < DateTime.Now)
            {
                controller.GetNextAlbums();
                lastUpdateTime = DateTime.Now;
            } 
        }
    }
}
