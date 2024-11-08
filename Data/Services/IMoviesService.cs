using eApplication.Data.ViewModels;
using eApplication.Models;
using eTickets.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eApplication.Data.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAllAsync(params Expression<Func<Movie, object>>[] includeProperties);

        Task AddAsync(Movie Movie);
        Task<Movie> GetByIdAsync(int id, params Expression<Func<Movie, object>>[] includeProperties);

        Task<Movie> UpdateAsync(int id, Movie Movie);

        Task DeleteAsync(int id);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
