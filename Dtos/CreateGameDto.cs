using System.ComponentModel.DataAnnotations;

namespace myGames.api.Dtos;

public record class CreateGameDto(

    [Required][StringLength(50)] string Name,

    [Required][StringLength(50)] string Genre,

    [Required][StringLength(50)] string Platform,

    [Required] DateOnly ReleaseDate
);
