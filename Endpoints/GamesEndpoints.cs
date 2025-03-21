namespace myGames.api.Endpoints;

using Microsoft.EntityFrameworkCore;
using myGames.api.Data;
using myGames.api.Dtos;
using myGames.api.Entities;

public static class GamesEndpoints
{
    private const string GetGameEndpointName = "GetGameById";
    private static readonly List<GameSummaryDto> games = [

        new (
        1,
        "League of Legends",
        "MOBA",
        "PC",
        new DateOnly(2009, 10, 27)
    )
    ,
    new (
        2,
        "Hades",
        "Roguelike",
        "PC",
        new DateOnly(2020, 9, 17)
    )
    ,
    new (
        3,
        "Borderlands 2",
        "FPS",
        "PC",
        new DateOnly(2012, 9, 18)
    )
    ,
    new (
        4,
        "A Short Hike",
        "Adventure",
        "PC",
        new DateOnly(2019, 7, 30)
    )
    ,
    new (
        5,
        "Celeste",
        "Platformer",
        "PC",
        new DateOnly(2018, 1, 25)
    )
    ,
    new (
        6,
        "Ori and the Will of the Wisps",
        "Platformer",
        "PC",
        new DateOnly(2020, 3, 11)
    ),
    new (
        7,
        "The Coffin Of Andy and Leyley",
        "Horror",
        "PC",
        new DateOnly(2024, 2, 14) // Adjust date as needed
    ),
    new (
        8,
        "MiSide",
        "Psychological Horror",
        "PC",
        new DateOnly(2024, 12, 11) // Adjust if needed
    ),

];

    public static WebApplication MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/games").WithParameterValidation();
        // GET /
        group.MapGet("/", (GameStoreContext dbContext) =>
            dbContext.Games.
                      Include(game => game.Genre).
                      Select(game => game.ToGameSummaryDto()).
                      AsNoTracking());

        // GET /1
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);
            Console.WriteLine(game);
            return game is not null ? Results.Ok(game.ToGameDetailsDto()) : Results.NotFound();

        }).WithName(GetGameEndpointName);

        // POST 
        group.MapPost("/", (CreateGameDto gameDto, GameStoreContext dbContext) =>
        {
            Game game = gameDto.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
        });

        // PUT /1
        group.MapPut("/{id}", (int id, UpdateGameDto gameDto, GameStoreContext dbContext) =>
        {
            var existingGame = dbContext.Games.Find(id);
            if (existingGame is null) return Results.NotFound();

            dbContext.Entry(existingGame).CurrentValues.SetValues(gameDto.ToEntity(id));
            dbContext.SaveChanges();

            return Results.NoContent();


        });

        // DELETE /1
        group.MapDelete("/{id}", (int id , GameStoreContext dbContext) =>
        {
            
            dbContext.Games.Where(game => game.Id == id).ExecuteDelete();
            dbContext.SaveChanges();

            return Results.NoContent();

        });
        return app;
    }

}

