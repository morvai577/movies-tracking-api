using Movies.Application.Models;

namespace Movies.Application.Services;

public interface IMovieService
{
    Task<bool> CreateAsync(Movie movie, CancellationToken token = default);
    Task<Movie?> GetByIdAsync(Guid id, Guid? userid = default, CancellationToken token = default);
    Task<Movie?> GetBySlugAsync(string slug, Guid? userid = default, CancellationToken token = default);
    Task<IEnumerable<Movie>> GetAllAsync(Guid? userid = default, CancellationToken token = default);
    Task<Movie?> UpdateAsync(Movie movie, Guid? userid = default, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}
