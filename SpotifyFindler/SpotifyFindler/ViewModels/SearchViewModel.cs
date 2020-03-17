using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Models;

namespace SpotifyFindler.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private Search searchResult = new Search();

        public Search SearchResult
        {
            get { return searchResult; }
            set { searchResult = value; OnPropertyChanged(new PropertyChangedEventArgs("SearchResult")); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
