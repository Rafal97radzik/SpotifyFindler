using SpotifyAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler.ViewModels
{
    public class SearchAlbumViewModel
    {
        public ObservableCollection<Item> Albums { get; set; }

        public SearchAlbumViewModel()
        {
            Albums = new ObservableCollection<Item>();
        }
    }
}
