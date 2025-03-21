namespace myGames.api.Endpoints;
using myGames.api.Dtos;

public static class GamesEndpoints
{
    private const string GetGameEndpointName = "GetGameById";
    private static readonly List<GameDtos> games = [

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
        group.MapGet("/", () => games);

        // GET /1
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.FirstOrDefault(x => x.Id == id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GetGameEndpointName);

        // POST 
        group.MapPost("", (CreateGameDto gameDto) =>
        {
            var game = new GameDtos(games.Max(x => x.Id) + 1, gameDto.Name, gameDto.Genre, gameDto.Platform, gameDto.ReleaseDate);
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        // PUT /1
        group.MapPut("/{id}", (int id, UpdateGameDto gameDto) =>
        {
            var game = games.FirstOrDefault(x => x.Id == id);
            if (game is null) return Results.NotFound();
            var updatedGame = new GameDtos(game.Id, gameDto.Name, gameDto.Genre, gameDto.Platform, gameDto.ReleaseDate);
            games[games.IndexOf(game)] = updatedGame;
            return Results.NoContent();
        });

        // DELETE /1
        group.MapDelete("/{id}", (int id) =>
        {
            var game = games.FirstOrDefault(x => x.Id == id);
            if (game is null) return Results.NotFound();
            games.Remove(game);
            return Results.NoContent();
        });
        return app;
    }

}

