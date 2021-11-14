using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutTest.Services.NetworkService
{
    public static class ApiConstants
    {

        public static string GetMoviesUri(string searchTerm)
        {
            return $"https://www.omdbapi.com/?apikey=fc857145&s={searchTerm}&page=1";
        }

    }
}
