namespace myGames.api.Dtos;

public record class GameSummaryDto(
    
    int Id,
    
    string Name,
    
    List<string> Genres,

    string Platform,

    DateOnly ReleaseDate
);