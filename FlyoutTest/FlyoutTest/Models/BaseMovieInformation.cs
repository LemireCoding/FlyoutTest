using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutTest.Models
{
    public class BaseMovieInformation
    {
        public BaseMovieInformation(string title, string poster, string imdbID, string type, string year)
        {
            Title = title;
            Poster = poster;
            ImdbID = imdbID;
            Type = type;
            Year = year;
        }

        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
