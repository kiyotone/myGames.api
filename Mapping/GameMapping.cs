using myGames.api.Dtos;
using myGames.api.Entities;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto dto)
    {
        return new Game
        {
            Name = dto.Name,
            GenreId = dto.GenreId,
            Platform = dto.Platform,
            ReleaseDate = dto.ReleaseDate
        };
    }

    public static Game ToEntity(this UpdateGameDto dto , int id)
    {
        return new Game
        {
            Id = id,
            Name = dto.Name,
            GenreId = dto.GenreId,
            Platform = dto.Platform,
            ReleaseDate = dto.ReleaseDate
        };
    }

    public static GameDetailsDto ToGameDetailsDto(this Game entity)
    {
        return new GameDetailsDto(
            entity.Id,
            entity.Name,
            entity.GenreId,
            entity.Platform,
            entity.ReleaseDate
        );
    }

    public static GameSummaryDto ToGameSummaryDto(this Game entity)
    {
        return new GameSummaryDto(
            entity.Id,
            entity.Name,
            entity.Genre!.Name,
            entity.Platform,
            entity.ReleaseDate
        );
    }
}
