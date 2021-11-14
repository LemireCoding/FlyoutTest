using FlyoutTest.Data_Access;
using FlyoutTest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FlyoutTest.Services
{
    public static class MovieService
    {
        private static IRepository<Movie> movieRepo = null;
        static async Task Init()
        {

            if (movieRepo != null)
            {
                return;
            }

            movieRepo = new Repository<Movie>();

        }

        public static async Task AddMovie(string title, string genre, string image)
        {
            await Init();

            await movieRepo.SaveAsync(new Movie
            {
                Title = title,
                Genre = genre,
                Image = image
            });


            

        }

        public static async Task RemoveMovie(Movie movie)
        {
            await Init();
       
            await movieRepo.DeleteAsysnc(movie);
        }

        public static async Task<Movie> GetMovie(int id)
        {
            await Init();
            return await movieRepo.GetById(id);
        }

        public static async Task<IEnumerable<Movie>> GetMovies()
        {
            await Init();

            var movies = await movieRepo.GetAllAsync();

            return movies;
        }
    }
}
