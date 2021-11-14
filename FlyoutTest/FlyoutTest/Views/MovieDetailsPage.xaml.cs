using FlyoutTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyoutTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(MovieId),nameof(MovieId))]
    public partial class MovieDetailsPage : ContentPage
    {
        public string MovieId { get; set; }
        public MovieDetailsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            bool good = int.TryParse(MovieId, out int result);

            if (good)
            {
                BindingContext = await MovieService.GetMovie(result);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}