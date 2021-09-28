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

        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
