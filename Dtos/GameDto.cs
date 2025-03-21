namespace myGames.api.Dtos;

public record class GameDtos(
    
    int Id,
    
    string Name,
    
    string Genre,

    string Platform,

    DateOnly ReleaseDate
);