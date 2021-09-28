using FlyoutTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace FlyoutTest.ViewModels
{
    class MovieListViewModel: ViewModelBase
    {
        public ObservableRangeCollection<Movie> MovieList { get; set; }

        public MovieListViewModel()
        {
            Title = "Movie List";
            MovieList = new ObservableRangeCollection<Movie>();
            MovieList.Add(new Movie
            {
                Title = "The ShawShank Redemption",
                Image = "https://m.media-amazon.com/images/M/MV5BNDYwOWUyMDItZTlkZi00YzYxLThlMmMtMzM5Yzk2NjVkZDliXkEyXkFqcGdeQXVyNjMwMzc3MjE@._V1_QL75_UX280_CR0,0,280,414_.jpg"
            }
                );

            MovieList.Add(new Movie
            {
                Title = "Army of redemption",
                Image = "https://m.media-amazon.com/images/M/MV5BYjhlYTAwNWEtYWNkNC00MjdjLTk3NDktNzQyYWNmYjA2OGEzXkEyXkFqcGdeQXVyMTAzMDg4NzU0._V1_QL75_UX280_CR0,0,280,414_.jpg"
            }
               );

            MovieList.Add(new Movie
            {
                Title = "Army of Thieves",
                Image = "https://m.media-amazon.com/images/M/MV5BZGRlODFlNTItZWFhZS00NjU5LTliNDUtNjUxMGJhMGZhYjFmXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_QL75_UY414_CR26,0,280,414_.jpg"
            }
               );
        }
    }
}
