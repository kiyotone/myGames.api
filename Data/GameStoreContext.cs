using Microsoft.EntityFrameworkCore;
using myGames.api.Entities;

namespace myGames.api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
           new Genre { Id = 1, Name = "Action" },
           new Genre { Id = 2, Name = "Adventure" },
           new Genre { Id = 3, Name = "RPG" },
           new Genre { Id = 4, Name = "Simulation" },
           new Genre { Id = 5, Name = "Strategy" },
           new Genre { Id = 6, Name = "Sports" },
           new Genre { Id = 7, Name = "Puzzle" },
           new Genre { Id = 8, Name = "MOBA" },
           new Genre { Id = 9, Name = "Horror" },
           new Genre { Id = 10, Name = "Platformer" },
           new Genre { Id = 11, Name = "Roguelike" },
           new Genre { Id = 12, Name = "FPS" },
           new Genre { Id = 13, Name = "Psychological Horror" } // Added missing genre
       );

    }

}
