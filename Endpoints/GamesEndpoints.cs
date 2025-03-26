namespace myGames.api.Endpoints;

using Microsoft.EntityFrameworkCore;
using myGames.api.Data;
using myGames.api.Dtos;
using myGames.api.Entities;

public static class GamesEndpoints
{
    private const string GetGameEndpointName = "GetGameById";

    public static WebApplication MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/games").WithParameterValidation();
        // GET /
        group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Games.
                      Include(game => game.Genres).
                      Select(game => game.ToGameSummaryDto()).
                      AsNoTracking().
                      ToListAsync()
                      );


        // GET /1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.Include(game => game.Genres).FirstOrDefaultAsync(game => game.Id == id);
            return game is not null ? Results.Ok(game.ToGameSummaryDto()) : Results.NotFound();

        }).WithName(GetGameEndpointName);

        // POST 
        group.MapPost("/", async (CreateGameDto gameDto, GameStoreContext dbContext) =>
        {
            Game game = gameDto.ToEntity();
            game.Genres = await dbContext.Genres.Where(genre => gameDto.GenreIds.Contains(genre.Id)).ToListAsync();

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
        });

        // PUT /1
        group.MapPut("/{id}", async (int id, UpdateGameDto gameDto, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);
            if (existingGame is null) return Results.NotFound();

            dbContext.Entry(existingGame).CurrentValues.SetValues(gameDto.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();


        });

        // DELETE /1
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {

            await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();


            return Results.NoContent();

        });
        return app;
    }

}

