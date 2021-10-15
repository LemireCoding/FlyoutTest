using FlyoutTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace FlyoutTest.ViewModels
{
    class MovieListViewModel: ViewModelBase
    {
        public ObservableRangeCollection<Movie> MovieList { get; set; }

        public ObservableRangeCollection<Grouping<string,Movie>> MovieGroups { get; set; }
        Movie previouslySelectedMovie;
        private Movie selectedMovie;
        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set {

                if( value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Title, "Ok");
                    previouslySelectedMovie = value;
                    value = null;
                }
                selectedMovie = value;
               
                OnPropertyChanged("SelectedMovie"); 
            }
        }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Movie> FavoriteCommand { get;  }
        public MovieListViewModel()
        {
            FavoriteCommand = new AsyncCommand<Movie>(Clicked);
            RefreshCommand = new AsyncCommand(Refresh);
            Title = "Movie List";
            MovieList = new ObservableRangeCollection<Movie>();

            MovieGroups = new ObservableRangeCollection<Grouping<string, Movie>>();

            MovieList.Add(new Movie
            {
                Title = "The ShawShank Redemption",
                Genre = "Action",
                Image = "https://m.media-amazon.com/images/M/MV5BNDYwOWUyMDItZTlkZi00YzYxLThlMmMtMzM5Yzk2NjVkZDliXkEyXkFqcGdeQXVyNjMwMzc3MjE@._V1_QL75_UX280_CR0,0,280,414_.jpg"
            }
                );

            MovieList.Add(new Movie
            {
                Title = "Army of redemption",
                Genre = "Action",
                Image = "https://m.media-amazon.com/images/M/MV5BYjhlYTAwNWEtYWNkNC00MjdjLTk3NDktNzQyYWNmYjA2OGEzXkEyXkFqcGdeQXVyMTAzMDg4NzU0._V1_QL75_UX280_CR0,0,280,414_.jpg"
            }
               );

            MovieList.Add(new Movie
            {
                Title = "Army of Thieves",
                Genre = "Drama",
                Image = "https://m.media-amazon.com/images/M/MV5BZGRlODFlNTItZWFhZS00NjU5LTliNDUtNjUxMGJhMGZhYjFmXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_QL75_UY414_CR26,0,280,414_.jpg"
            }
               );

            MovieList.Add(new Movie
            {
                Title = "Army of Thieves",
                Genre = "Drama",
                Image = "https://m.media-amazon.com/images/M/MV5BZGRlODFlNTItZWFhZS00NjU5LTliNDUtNjUxMGJhMGZhYjFmXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_QL75_UY414_CR26,0,280,414_.jpg"
            }
               );

            MovieList.Add(new Movie
            {
                Title = "Army of Thieves",
                Genre = "Drama",
                Image = "https://m.media-amazon.com/images/M/MV5BZGRlODFlNTItZWFhZS00NjU5LTliNDUtNjUxMGJhMGZhYjFmXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_QL75_UY414_CR26,0,280,414_.jpg"
            }
               );

            MovieList.Add(new Movie
            {
                Title = "Army of Thieves",
                Genre = "Drama",
                Image = "https://m.media-amazon.com/images/M/MV5BZGRlODFlNTItZWFhZS00NjU5LTliNDUtNjUxMGJhMGZhYjFmXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_QL75_UY414_CR26,0,280,414_.jpg"
            }
               );

            MovieList.Add(new Movie
            {
                Title = "Army of Thieves",
                Genre = "Drama",
                Image = "https://m.media-amazon.com/images/M/MV5BZGRlODFlNTItZWFhZS00NjU5LTliNDUtNjUxMGJhMGZhYjFmXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_QL75_UY414_CR26,0,280,414_.jpg"
            }
               );

            MovieList.Add(new Movie
            {
                Title = "Army of Thieves",
                Genre = "Fantasy",
                Image = "https://m.media-amazon.com/images/M/MV5BZGRlODFlNTItZWFhZS00NjU5LTliNDUtNjUxMGJhMGZhYjFmXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_QL75_UY414_CR26,0,280,414_.jpg"
            }
               );

            MovieList.Add(new Movie
            {
                Title = "Army of Thieves",
                Genre = "Fantasy",
                Image = "https://m.media-amazon.com/images/M/MV5BZGRlODFlNTItZWFhZS00NjU5LTliNDUtNjUxMGJhMGZhYjFmXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_QL75_UY414_CR26,0,280,414_.jpg"
            }
               );

            MovieGroups.Add(new Grouping<string, Movie>("Action", new[] { MovieList[3] }));

            MovieGroups.Add(new Grouping<string, Movie>("Drama", MovieList.Take(2)));

            MovieGroups.Add(new Grouping<string, Movie>("Fantasy",MovieList.Where(x=>x.Genre.Contains("Fantasy"))));
        }

        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Clicked(Movie movie)
        {
            if(movie == null)
            {
                return;
            } else
            {
                await Application.Current.MainPage.DisplayAlert("Favorited", movie.Title, "Ok");
            }
        }
    }
}
