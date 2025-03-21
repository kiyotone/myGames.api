namespace myGames.api.Dtos;

public record class GameDetailsDto(
    
    int Id,
    
    string Name,
    
    int GenreId,

    string Platform,

    DateOnly ReleaseDate
);