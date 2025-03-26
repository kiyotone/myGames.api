namespace myGames.api.Dtos;

public record class GameDetailsDto(
    
    int Id,
    
    string Name,
    
    List<int> GenreIds,

    string Platform,

    DateOnly ReleaseDate
);