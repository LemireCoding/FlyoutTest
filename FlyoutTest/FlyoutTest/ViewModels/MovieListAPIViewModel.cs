using FlyoutTest.Models;
using FlyoutTest.Services.NetworkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace FlyoutTest.ViewModels
{
    public class MovieListAPIViewModel : ViewModelBase
    {
        private INetworkService networkService;

        public MovieListAPIViewModel()
        {
            OnPropertyChanged("Items");

        }
        public ObservableRangeCollection<BaseMovieInformation> Items { get; set; }
        public MovieListAPIViewModel(INetworkService networkService)
        {
            this.networkService = networkService;
            GetMovieData();
            OnPropertyChanged("Items");
        }

        private async void GetMovieData()
        {
            var result = await networkService.GetAsync<ListOfMovies>(ApiConstants.GetMoviesUri("avengers"));

            Items = new ObservableRangeCollection<BaseMovieInformation>(result.Search.Select(x => new BaseMovieInformation( x.Title, x.Poster, x.ImdbID, x.Type, x.Year)));
            OnPropertyChanged("Items");
        }
        
            
    }
}
