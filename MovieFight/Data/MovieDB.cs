using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MovieFight.Model;

namespace MovieFight.Data
{
    public class MovieDB
    {
        readonly SQLiteAsyncConnection _database;
        public MovieDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Movie>().Wait();
        }

        public Task<List<Movie>> GetGirlMoviesAsync()
        {
            return _database.Table<Movie>().Where(i => i.Column == 0).ToListAsync();
        }

        public Task<List<Movie>> GetBoyMoviesAsync()
        {
            return _database.Table<Movie>().Where(i => i.Column == 1).ToListAsync();
        }

        public Task<Movie> GetItemAsync(string movieTitle)
        {
            return _database.Table<Movie>().Where(i => i.Title == movieTitle).FirstOrDefaultAsync();
        }

        public Task<int> SaveMovieAsync(Movie movie)
        {
            return _database.InsertAsync(movie);
        }

        public Task<int> DeleteItemAsync(Movie movie)
        {
            return _database.DeleteAsync(movie);
        }
    }
}
