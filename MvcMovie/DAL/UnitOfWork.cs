using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieContext _context;
        private IRepository<Movie> movieRepository;
        private IRepository<Rating> ratingRepository;

        public UnitOfWork(MovieContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public IRepository<Movie> MovieRepository
        {
            get
            {
                if (movieRepository == null)
                {
                    movieRepository = new GenricRepository<Movie>(_context);
                }
                return movieRepository;
            }
        }
        public IRepository<Rating> RatingRepository
        {
            get
            {
                if (ratingRepository == null)
                {
                    ratingRepository = new GenricRepository<Rating>(_context);
                }
                return ratingRepository;
            }
        }
    }
}
