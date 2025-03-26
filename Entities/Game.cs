using System;
using System.Collections.Generic;

namespace myGames.api.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Platform { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public List<int> GenreIds { get; set; } = new();
    public List<Genre> Genres { get; set; } = [];
}
