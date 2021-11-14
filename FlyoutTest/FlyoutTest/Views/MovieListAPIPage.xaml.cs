using FlyoutTest.Services.NetworkService;
using FlyoutTest.ViewModels;
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
    public partial class MovieListAPIPage : ContentPage
    {
        public MovieListAPIPage()
        {

            InitializeComponent();
            BindingContext = new MovieListAPIViewModel(new NetworkService());
        }
    }
}