using System;

namespace myGames.api.Entities;

public class Game
{
    
    public int Id { get; set; }
    public required string Name { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;
    public required string Platform { get; set; }
    public DateOnly ReleaseDate { get; set; }

}
