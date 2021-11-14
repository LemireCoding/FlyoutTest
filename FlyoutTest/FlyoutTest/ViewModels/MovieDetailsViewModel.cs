
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace FlyoutTest.ViewModels
{
    public class MovieDetailsViewModel
    {
        AsyncCommand GoBackCommand { get; }

        public MovieDetailsViewModel()
        {
            GoBackCommand = new AsyncCommand(GoBack);
        }

        private async Task GoBack()
        {
            await AppShell.Current.GoToAsync("..");
        }
    }
}
