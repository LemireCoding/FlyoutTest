using FlyoutTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace FlyoutTest.ViewModels
{
    public class AddMovieViewModel : ViewModelBase
    {
        string movieTitle, genre, image;
        public string MovieTitile { get => movieTitle; set => SetProperty(ref movieTitle, value); }

        public string Genre { get => genre; set => SetProperty(ref genre, value); }
        public string Image { get => image; set => SetProperty(ref image, value); }

        public AsyncCommand SaveCommand { get; }

        public AddMovieViewModel()
        {
            Title = "Add Movie";
            SaveCommand = new AsyncCommand(Save);
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(movieTitle) ||
                string.IsNullOrWhiteSpace(genre) ||
                string.IsNullOrWhiteSpace(image))
            {
                return;
            }

            await MovieService.AddMovie(movieTitle, genre, image);
            await AppShell.Current.GoToAsync("..");

        }
    }
}
