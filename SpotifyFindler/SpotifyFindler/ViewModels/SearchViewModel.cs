using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Models;

namespace SpotifyFindler.ViewModels
{
    public class SearchViewModel
    {
        public ObservableCollection<Item> Albums { get; set; }   
        public ObservableCollection<Item> Tracks { get; set; }
        public ObservableCollection<Item> Playlists { get; set; }
        public ObservableCollection<Item> Artists { get; set; }

        public SearchViewModel()
        {
            Albums = new ObservableCollection<Item>();
            Tracks = new ObservableCollection<Item>();
            Playlists = new ObservableCollection<Item>();
            Artists = new ObservableCollection<Item>();
        }
    }
}
