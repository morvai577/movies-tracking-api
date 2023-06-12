using Dapper;

namespace Movies.Application.Database;

public class DbInitialiser
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public DbInitialiser(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    public async Task InitializeAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        // Create movies table if it doesn't exist
        await connection.ExecuteAsync("""
            create table if not exists movies (
                id UUID primary key,
                slug TEXT not null,
                title TEXT not null,
                yearofrelease integer not null);
        """);

        // Create unique index for lookup by slug
        await connection.ExecuteAsync("""
            create unique index concurrently if not exists movies_slug_idx
            on movies
            using btree(slug);
        """);

        // Create genre table if it doesn't exist
        await connection.ExecuteAsync("""
            create table if not exists genres (
                movieId UUID references movies (id),
                name TEXT not null);
        """);

        await connection.ExecuteAsync("""
            create table if not exists ratings (
                userid UUID,
                movieid UUID references movies (id),
                rating integer not null,
                primary key (userid, movieid));
        """);
    }
}
