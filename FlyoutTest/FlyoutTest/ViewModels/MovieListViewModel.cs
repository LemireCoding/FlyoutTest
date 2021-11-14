using FlyoutTest.Models;
using FlyoutTest.Services;
using FlyoutTest.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace FlyoutTest.ViewModels
{
    class MovieListViewModel: ViewModelBase
    {
        public ObservableRangeCollection<Movie> MovieList { get; set; }
        public ObservableRangeCollection<Grouping<string, Movie>> MovieGroups { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Movie> FavoriteCommand { get; }

        public AsyncCommand<Movie> RemoveCommand { get; }
        public AsyncCommand AddCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }


        public AsyncCommand SelectedCommand { get; }

        private Movie previouslySelectedMovie;

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set => SetProperty(ref selectedMovie, value);
        }

        public MovieListViewModel()
        {

            Title = "Movie List";



            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Movie>(DisplayFavorite);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
            MovieList = new ObservableRangeCollection<Movie>();
            AddCommand = new AsyncCommand(AddMovie);
            RemoveCommand = new AsyncCommand<Movie>(RemoveMovie);
            SelectedCommand = new AsyncCommand(Selected);

            MovieGroups = new ObservableRangeCollection<Grouping<string, Movie>>();

            initMovies();
            createGroups();

        }

        private async Task Selected()
        {
            if(SelectedMovie == null)
            {
                return;
            }

            var route = $"{nameof(MovieDetailsPage)}?MovieId={SelectedMovie.Id}";
            await Shell.Current.GoToAsync(route);

            selectedMovie = null;
        }

        private Task RemoveMovie(Movie arg)
        {
            return MovieService.RemoveMovie(arg);
        }

        private async Task AddMovie()
        {
            /**
            var title = await App.Current.MainPage.DisplayPromptAsync
                ("Titile", "Enter the movie's name:", "Ok", "Cancel");
            var genre = await App.Current.MainPage.DisplayPromptAsync
                ("Genre", "Enter the movie's genre:", "Ok", "Cancel");
            var image = await App.Current.MainPage.DisplayPromptAsync
               ("Image", "Enter the movie's image:", "Ok", "Cancel");

            await MovieService.AddMovie(title, genre, image);
            await Refresh();
            **/
            var route = $"{nameof(AddMoviePage)}";
            await Shell.Current.GoToAsync(route);
        }




        private void DelayLoadMore(object obj)
        {
            if (MovieList.Count <= 10)
            {
                return;
            }
            else
            {
                LoadMore();
            }
        }

        private void Clear(object obj)
        {
            MovieList.Clear();
            MovieGroups.Clear();
        }

        private void LoadMore()
        {
            if (MovieList.Count >= 20)
                return;

            MovieList.Add(new Movie
            {

                Title = "TEST MOVIE",
                Genre = "Sci-Fi",
                Image = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UY67_CR0,0,45,67_AL_.jpg"

            });
            MovieGroups.Clear();
            MovieGroups.Add(new Grouping<string, Movie>("Action", MovieList.Where(x =>
                x.Genre.Contains("Action"))));
            MovieGroups.Add(new Grouping<string, Movie>("Drama", MovieList.Where(x =>
                x.Genre.Contains("Drama"))));
            MovieGroups.Add(new Grouping<string, Movie>("Crime", MovieList.Where(x =>
                x.Genre.Contains("Crime"))));
            MovieGroups.Add(new Grouping<string, Movie>("Sci-Fi", MovieList.Where(x =>
                x.Genre.Contains("Sci-Fi"))));
            MovieGroups.Add(new Grouping<string, Movie>("Biography", MovieList.Where(x =>
                x.Genre.Contains("Biography"))));

        }

        public void createGroups()
        {

            MovieGroups.Clear();

            MovieGroups.Add(new Grouping<string, Movie>("Action", MovieList.Where(x =>
                x.Genre.Contains("Action"))));
            MovieGroups.Add(new Grouping<string, Movie>("Drama", MovieList.Where(x =>
                x.Genre.Contains("Drama"))));
            MovieGroups.Add(new Grouping<string, Movie>("Crime", MovieList.Where(x =>
                x.Genre.Contains("Crime"))));
            MovieGroups.Add(new Grouping<string, Movie>("Sci-Fi", MovieList.Where(x =>
                x.Genre.Contains("Sci-Fi"))));
            MovieGroups.Add(new Grouping<string, Movie>("Biography", MovieList.Where(x =>
                x.Genre.Contains("Biography"))));
        }

        private void initMovies()
        {
            MovieList.Add(new Movie
            {

                Title = "The Shawshank Redemption",
                Genre = "Drama",
                Image = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UY67_CR0,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "The Godfather",
                Genre = "Crime",
                Image = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY67_CR1,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "The Godfather: Part II",
                Genre = "Crime",
                Image = "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY67_CR1,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "The Dark Knight",
                Genre = "Action",
                Image = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UY67_CR0,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "12 Angry Men",
                Genre = "Crime",
                Image = "https://m.media-amazon.com/images/M/MV5BMWU4N2FjNzYtNTVkNC00NzQ0LTg0MjAtYTJlMjFhNGUxZDFmXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_UX45_CR0,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "Schindler's List",
                Genre = "Biography",
                Image = "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX45_CR0,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "The Lord of the Rings: The Return of the King",
                Genre = "Adventure",
                Image = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY67_CR0,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "Fight Club",
                Genre = "Drama",
                Image = "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX45_CR0,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "Forrest Gump",
                Genre = "Drama",
                Image = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UY67_CR0,0,45,67_AL_.jpg"

            });
            MovieList.Add(new Movie
            {

                Title = "Inception",
                Genre = "Sci-Fi",
                Image = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UY67_CR0,0,45,67_AL_.jpg"

            });

        }

        private async Task DisplayFavorite(Movie movie)
        {
            if (movie == null)
            {
                return;
            }
            await Application.Current.MainPage.DisplayAlert("Movie Favorited", movie.Title, "Ok");
        }

        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);

           // MovieList.Clear();

            var movies = await MovieService.GetMovies();

            MovieList.ReplaceRange(movies);

            createGroups();

            IsBusy = false;
        }

    }
}
