using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutTest.Models
{
    class Movie
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string genre;
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
