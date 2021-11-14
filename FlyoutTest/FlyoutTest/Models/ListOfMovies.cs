using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutTest.Models
{
    public class ListOfMovies
    {
        public List<BaseMovieInformation> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}

