using System.ComponentModel.DataAnnotations;

namespace myGames.api.Dtos;

public record class UpdateGameDto(
    
    [Required] [StringLength(50)]  string Name,
    
    [Required] List<int> GenreIds,

    [Required] [StringLength(50)]  string Platform,

    [Required] DateOnly ReleaseDate
);
