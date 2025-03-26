using myGames.api.Dtos;
using myGames.api.Entities;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto dto)
    {
        return new Game
        {
            Name = dto.Name,
            GenreIds = dto.GenreIds,
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
            GenreIds = dto.GenreIds,
            Platform = dto.Platform,
            ReleaseDate = dto.ReleaseDate
        };
    }

    public static GameDetailsDto ToGameDetailsDto(this Game entity)
    {
        return new GameDetailsDto(
            entity.Id,
            entity.Name,
            entity.GenreIds,
            entity.Platform,
            entity.ReleaseDate
        );
    }

    public static GameSummaryDto ToGameSummaryDto(this Game entity)
    {
        return new GameSummaryDto(
            entity.Id,
            entity.Name,
            entity.Genres.Select(genre => genre.Name).ToList(),
            entity.Platform,
            entity.ReleaseDate
        );
    }
}
