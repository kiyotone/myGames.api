using Microsoft.EntityFrameworkCore;

namespace myGames.api.Data;

public static class DataExtensions
{

    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<GameStoreContext>();
        await context.Database.MigrateAsync();
      }

}
