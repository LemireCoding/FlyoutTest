
using FlyoutTest.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FlyoutTest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddMoviePage), typeof(AddMoviePage));
            Routing.RegisterRoute(nameof(MovieDetailsPage), typeof(MovieDetailsPage));

        }
    }
}
