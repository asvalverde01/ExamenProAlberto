using ExamenProAlberto.Data;
using ExamenProAlberto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProAlberto.Services
{
    public class MovieService
    {
        private MovieContext _context;

        public MovieService()
        {
            _context = new MovieContext();
            _context.Database.EnsureCreated();
        }

        public void AddMovie(AV_Rootobject movie)
        {
            MovieData movieData = new MovieData
            {
                imdbID = movie.imdbID,
                Title = movie.Title,
                Year = movie.Year,
                Rated = movie.Rated,
                Released = movie.Released
            };
            _context.Movies.Add(movieData);
            _context.SaveChanges();
        }

        public List<MovieData> GetMovies()
        {
            return _context.Movies.ToList();
        }
    }

}
