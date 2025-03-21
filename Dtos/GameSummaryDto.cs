namespace myGames.api.Dtos;

public record class GameSummaryDto(
    
    int Id,
    
    string Name,
    
    string Genre,

    string Platform,

    DateOnly ReleaseDate
);